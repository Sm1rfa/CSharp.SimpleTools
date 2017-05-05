using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows;
using Newtonsoft.Json;

namespace Extensions.TranslateHelper
{
    public class Translator
    {
        private List<Language> langList = new List<Language>();

        public Translator()
        {
            this.PopulateLanguageList();
        }

        public List<Language> LanguageList
        {
            get
            {
                return (langList.OrderBy(l => l.lang).ToList());
            }
        }

        private void PopulateLanguageList()
        {
            langList.Add(new Language { lang = "Arabic", langCode = "ar" });
            langList.Add(new Language { lang = "Bulgarian", langCode = "bg" });
            langList.Add(new Language { lang = "Czech", langCode = "cs" });
            langList.Add(new Language { lang = "Danish", langCode = "da" });
            langList.Add(new Language { lang = "German", langCode = "de" });
            langList.Add(new Language { lang = "English", langCode = "en" });
            langList.Add(new Language { lang = "Estonian", langCode = "et" });
            langList.Add(new Language { lang = "Finnish", langCode = "fi" });
            langList.Add(new Language { lang = "Dutch", langCode = "nl" });
            langList.Add(new Language { lang = "Greek", langCode = "el" });
            langList.Add(new Language { lang = "Hebrew", langCode = "he" });
            langList.Add(new Language { lang = "Haitian Creole", langCode = "ht" });
            langList.Add(new Language { lang = "Hindi", langCode = "hi" });
            langList.Add(new Language { lang = "Hungarian", langCode = "hu" });
            langList.Add(new Language { lang = "Indonesian", langCode = "id" });
            langList.Add(new Language { lang = "Italian", langCode = "it" });
            langList.Add(new Language { lang = "Japanese", langCode = "ja" });
            langList.Add(new Language { lang = "Korean", langCode = "ko" });
            langList.Add(new Language { lang = "Lithuanian", langCode = "lt" });
            langList.Add(new Language { lang = "Latvian", langCode = "lv" });
            langList.Add(new Language { lang = "Norwegian", langCode = "no" });
            langList.Add(new Language { lang = "Polish", langCode = "pl" });
            langList.Add(new Language { lang = "Portuguese", langCode = "pt" });
            langList.Add(new Language { lang = "Romanian", langCode = "ro" });
            langList.Add(new Language { lang = "Spanish", langCode = "es" });
            langList.Add(new Language { lang = "Russian", langCode = "ru" });
            langList.Add(new Language { lang = "Slovak", langCode = "sk" });
            langList.Add(new Language { lang = "Slovene", langCode = "sl" });
            langList.Add(new Language { lang = "Swedish", langCode = "sv" });
            langList.Add(new Language { lang = "Thai", langCode = "th" });
            langList.Add(new Language { lang = "Turkish", langCode = "tr" });
            langList.Add(new Language { lang = "Ukranian", langCode = "uk" });
            langList.Add(new Language { lang = "Vietnamese", langCode = "vi" });
            langList.Add(new Language { lang = "Simplified Chinese", langCode = "zh-CHS" });
            langList.Add(new Language { lang = "Traditional Chinese", langCode = "zh-CHT" });
        }

        public string GetTranslatedText(string textToTranslate, string fromLang, string toLang)
        {
            string translation;
            // Yandex docs https://tech.yandex.com/translate/doc/dg/reference/translate-docpage/
            var key = "trnsl.1.1.20170216T162231Z.4d4d2aa03cdbc31a.877f8148aed5ee857db8c7a12c6f883fee94d2b1";

            if (fromLang != toLang)
            {
                // samples https://translate.yandex.net/api/v1.5/tr.json/translate?key=<key>&text=hello&lang=en-ru
                string uri = "https://translate.yandex.net/api/v1.5/tr.json/translate?key=" + key + "&text=" + textToTranslate +"&lang=" + fromLang + "-" + toLang;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

                try
                {
                    WebResponse response = request.GetResponse();
                    Stream strm = response.GetResponseStream();
                    using (var sr = new StreamReader(strm))
                    {
                        translation = sr.ReadToEnd();
                    }
                    //StreamReader sr = new StreamReader(strm);
                    response.Close();
                    //sr.Close();
                }
                catch (WebException)
                {
                    MessageBox.Show("Ensure that you are connected to the internet.", "Error");
                    return (string.Empty);
                }
            }
            else
            {
                MessageBox.Show("Will not translate to the same language.", "Error");
                return (string.Empty);
            }

            var json = JsonConvert.DeserializeObject<LanguageModel>(translation);
            return json.text[0];
        }
    }
}
