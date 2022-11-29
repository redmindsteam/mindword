using Integrated.Interfaces;
using Integrated.Models.DefinationAPIModels;
using MindWord.Domain.Constants;
using MindWord.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integrated.Services
{
    public class DefinationAPIService : IDefinationAPIService
    {

        private readonly string _definationApiUrl = DbConstants.DEFINATION_API_URL;
        private readonly string _wordAudioPath = DbConstants.WORD_AUDIO_PATH;
        public async Task<(bool successful, byte[]? voice)> GetVoiceAsync(List<Phonetic> phonetics)
        {
            byte[]? body;
            foreach (var phonetic in phonetics)
            {
                var voiceApiUrl = phonetic.audio;
                if (voiceApiUrl != null)
                {
                    var client = new HttpClient();
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get,
                        RequestUri = new Uri(voiceApiUrl),
                    };
                    var response = await client.SendAsync(request);

                    response.EnsureSuccessStatusCode();
                    body = await response.Content.ReadAsByteArrayAsync();

                    return (successful: true, voice: body);

                }

            }
            return (successful: false, voice: null);
        }


        public async Task<(bool successful, Word word)> GetWordAsync(string word)
        {
            Word newWord = new Word();

            var WordDetail = await GetWordDeteilAsync(word);

            if (WordDetail != null)
            {
                var voice = await GetVoiceAsync(WordDetail.phonetics);
                if (voice.successful)
                {
                    if (!Directory.Exists(_wordAudioPath))
                    {
                        Directory.CreateDirectory(_wordAudioPath);
                    }
                    await File.WriteAllBytesAsync((_wordAudioPath + "/" + word + ".mp3"), voice.voice);
                    newWord.AudioPath = _wordAudioPath + "/" + word + ".mp3";
                }
                else
                    newWord.AudioPath = null;
                newWord.Name = word;
                newWord.Description = WordDetail.meanings[0].definitions[0].definition;
                newWord.CorrectCoins = 0;
                newWord.ErrorCoins = 0;

                return (true, newWord);
            }
            else
                return (false, null);


        }

        public async Task<WordDetail?> GetWordDeteilAsync(string word)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(_definationApiUrl + word),

            };
            var response = await client.SendAsync(request);

            var status = (int)response.StatusCode;
            try
            {
                if (status == 200)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    var json = JsonConvert.DeserializeObject<List<WordDetail>>(body);
                    return json[0];
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}