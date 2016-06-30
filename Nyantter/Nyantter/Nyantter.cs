using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;


namespace Nyantter
{
    public static class Statuses
    {
        //一般的なツイートの用法
        public async static Task<Tweet> update(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/statuses/update.json";
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            //Tweet result = Serialize.JsontoOwnTweet(resultstr, user);
            var result = new Tweet();
            return result;
        }

        public async static Task<Tweet> retweet(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = String.Format("https://api.twitter.com/1.1/statuses/retweet/" + postdata["id"] + ".json");
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            Tweet result = Serialize.JsontoTweet(resultstr);
            return result;
        }
        public async static Task<List<Tweet>> retweets_of_me(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = String.Format("https://api.twitter.com/1.1/statuses/retweet/" + postdata["id"] + ".json");
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            List<Tweet> result = Serialize.JsontoTweets(resultstr, oauth);
            return result;
        }
        public async static Task<Tweet> unretweet(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = String.Format("https://api.twitter.com/1.1/statuses/unretweet/" + postdata["id"] + ".json");
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            Tweet result = Serialize.JsontoTweet(resultstr);
            return result;
        }


        //ツイートの詳細を閲覧します
        public async static Task<Tweet> show(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/statuses/show.json";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            Tweet result = Serialize.JsontoTweet(resultstr);
            return result;
        }

        //ツイートを消去します
        public async static Task<Tweet> destroy(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/statuses/destroy/" + postdata["id"] + ".json";
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            Tweet result = Serialize.JsontoTweet(resultstr);
            return result;
        }

        //レストホームタイムラインの取得
        public async static Task<List<Tweet>> home_timeline(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/statuses/home_timeline.json";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            List<Tweet> result = Serialize.JsontoTweets(resultstr, oauth);
            return result;
        }
        public async static Task<List<Tweet>> mentions_timeline(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/statuses/mentions_timeline.json";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            List<Tweet> result = Serialize.JsontoTweets(resultstr, oauth);
            return result;
        }
        public async static Task<List<Tweet>> user_timeline(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/statuses/user_timeline.json";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            List<Tweet> result = Serialize.JsontoTweets(resultstr, oauth);
            return result;
        }

        public async static Task<string> oemed(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://publish.twitter.com/oembed";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            return resultstr;
        }
        public async static Task<string> retweeters(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/statuses/retweeters/ids.json";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            return resultstr;
        }

        public async static Task<List<Tweet>> lookup(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/statuses/lookup.json";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            List<Tweet> result = Serialize.JsontoTweets(resultstr, oauth);
            return result;
        }

    }
    public static class Search
    {
        public async static Task<List<Tweet>> tweets(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/search/tweets.json";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            List<Tweet> result = Serialize.JsontoTweets(resultstr, oauth);
            return result;

        }
    }
    public static class Streaming
    {


    }
    public static class DirectMessages
    {
        public async static Task<List<Tweet>> direct_messages(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/direct_messages.json";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            List<Tweet> result = Serialize.JsontoTweets(resultstr, oauth);
            return result;
        }
        public async static Task<List<Tweet>> sent(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/direct_messages/sent.json";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            List<Tweet> result = Serialize.JsontoTweets(resultstr, oauth);
            return result;
        }
        public async static Task<List<Tweet>> show(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/direct_messages/show.json";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            List<Tweet> result = Serialize.JsontoTweets(resultstr, oauth);
            return result;
        }
        public async static Task<List<Tweet>> destroy(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/direct_messages/destroy.json";
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            List<Tweet> result = Serialize.JsontoTweets(resultstr, oauth);
            return result;
        }
        public async static Task<List<Tweet>> New(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/direct_messages/new.json";
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            List<Tweet> result = Serialize.JsontoTweets(resultstr, oauth);
            return result;
        }

    }
    public static class Friendships
    {
        public async static Task<string> incoming(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/friendships/incoming.json";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            return resultstr;
        }
        public async static Task<string> outgoing(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/friendships/outgoing.json";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            return resultstr;
        }

        public async static Task<User> create(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/friendships/create.json";
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            User result = Serialize.JsontoUser(resultstr, true);
            return result;
        }
        public async static Task<User> destroy(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/friendships/destroy.json";
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            User result = Serialize.JsontoUser(resultstr, true);
            return result;
        }
        public async static Task<string> update(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/friendships/update.json";
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            return resultstr;
        }
        public async static Task<string> show(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/friendships/show.json";
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            return resultstr;
        }
        public async static Task<string> lookup(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/friendships/lookup.json";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            return resultstr;
        }

    }
    public static class Users
    {
        public async static Task<User> show(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/users/show.json";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            User result = Serialize.JsontoUser(resultstr, true);
            return result;
        }

        public async static Task<User> search(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/users/search.json";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            User result = Serialize.JsontoUser(resultstr, true);
            return result;
        }

        public async static Task<User> report_spam(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/users/report_spam.json";
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            User result = Serialize.JsontoUser(resultstr, true);
            return result;
        }

        public async static Task<string> profile_banner(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/users/profile_banner.json";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            return resultstr;
        }
        public async static Task<string> suggestions(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/users/suggestions.json";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            return resultstr;
        }
        //public async static Task<User> suggestions_slug(OAuth oauth,SortedDictionary<string, string> postdata)
        public async static Task<List<User>> lookup(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/users/lookup.json";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            List<User> result = Serialize.JsontoUsers(resultstr);
            return result;

        }

    }
    public static class SuggestedUsers
    { }
    public static class Favorites
    {
        //ふぁぼります
        public static async Task<Tweet> create(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/favorites/create.json";
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            Tweet result = Serialize.JsontoTweet(resultstr);
            return result;
        }

        //あんふぁぼります
        public static async Task<Tweet> destroy(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/favorites/destroy.json";
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            Tweet result = Serialize.JsontoTweet(resultstr);
            return result;
        }

        public async static Task<List<Tweet>> list(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/favorites/list.json";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            List<Tweet> result = Serialize.JsontoTweets(resultstr, oauth);
            return result;

        }
    }
    public static class Mutes
    {
        public async static Task<User> create(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/mutes/users/create.json";
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            User result = Serialize.JsontoUser(resultstr, true);
            return result;
        }
        public async static Task<User> destroy(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/mutes/users/destroy.json";
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            User result = Serialize.JsontoUser(resultstr, true);
            return result;
        }
        public async static Task<string> ids(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/mutes/users/ids.json";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            return resultstr;
        }
        public async static Task<string> list(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/mutes/users/list.json";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            return resultstr;
        }

    }
    public static class Blocks
    {
        public async static Task<List<User>> list(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/blocks/list.json";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            List<User> result = Serialize.JsontoUsers(resultstr);
            return result;

        }
        public async static Task<string> ids(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/blocks/ids.json";
            string resultstr = await oauth.RestGET(oauth, APIURL, postdata);
            return resultstr;

        }
        public async static Task<User> create(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/blocks/create.json";
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            User result = Serialize.JsontoUser(resultstr, true);
            return result;
        }
        public async static Task<User> destroy(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/blocks/destroy.json";
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            User result = Serialize.JsontoUser(resultstr, true);
            return result;
        }

    }
    public static class Lists
    {
        public async static Task<string> update(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/lists/update.json";
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            return resultstr;
        }
        public async static Task<string> create(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/lists/create.json";
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            return resultstr;
        }
        public async static Task<string> destroy(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/lists/destroy.json ";
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            return resultstr;
        }

        public async static Task<string> memberscreate(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/lists/members/create.json";
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            return resultstr;
        }
        public async static Task<string> membersdestroy(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/lists/members/destroy.json";
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            return resultstr;
        }

        public async static Task<User> membersshow(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/lists/members/show.json";
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            User result = Serialize.JsontoUser(resultstr, true);
            return result;
        }


    }
    public static class Account
    {
        public async static Task<string> settings(OAuth oauth, SortedDictionary<string, string> postdata)
        {
            string APIURL = "https://api.twitter.com/1.1/account/settings.json";
            string resultstr = await oauth.RestPOST(oauth, APIURL, postdata);
            return resultstr;
        }

    }

    //変換系
    public static class Serialize
    {
        //Tweetへの変換
        public static Tweet JsontoTweet(string result)
        {
            Tweet tweet = new Tweet();
            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(Tweet));

            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            tweet = (Tweet)dcjs.ReadObject(stream);
            User tweeteduser = new User();
            string userstring = Regex.Match(result, "(.*?)user\":{(.*?)}(.*?)").Groups[2].Value;
            if (userstring != "")
            {
                userstring = "{" + userstring + "}";
                tweeteduser = JsontoUser(userstring, false);

                //自分とユーザー名が一致している場合、画像ファイルの場所が指定されないのでここで画像を追加しておきます
                //if (tweeteduser.profile_image_url_https == null)
                //{
                //    tweeteduser.UserIcon_normal = user.icon;
                //    tweeteduser.screen_name = user.ScreenName;
                //    tweeteduser.name = user.UserName;

                //}

                tweet.user = tweeteduser;

                return tweet;
            }
            else
                return null;
        }
        public static List<Tweet> JsontoTweets(string result, OAuth user)
        {
            List<Tweet> tweet = new List<Tweet>();


            //処理をしやすくするために最初の文字を消去
            result = result.Remove(0, 1);
            //処理をしやすくするために後ろに適当な文字を入れる
            result += "]";

            StringReader jsonstring = new StringReader(result);
            List<string> tweetjson = new List<string>();

            //正規表現を用いて },{でテキストを切っていきます
            if (result.Length > 2)
            {
                //初期化
                string[] comparison = new string[3];
                comparison[0] = null;
                comparison[1] = null;
                comparison[2] = null;

                string text = null;
                while (jsonstring.Peek() > -1)
                {
                    comparison[2] = comparison[1];
                    comparison[1] = comparison[0];
                    comparison[0] = Convert.ToString(Convert.ToChar(jsonstring.Read()));
                    text += comparison[2];
                    if (String.Format("{0}{1}{2}", comparison[2], comparison[1], comparison[0]) == "},{")
                    {
                        tweetjson.Add(text);
                        comparison[1] = null;
                        //リセット
                        text = null;
                    }
                }
            }

            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(Tweet));

            //ツイート1つ1つの処理はこちらから
            for (int i = 0; i < tweetjson.Count; i++)
            {
                //jsonデータを使える形式に成型します
                string text = null;
                text += tweetjson[i];
                text += null;

                MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(text));
                Tweet a_tweet = (Tweet)dcjs.ReadObject(stream);

                //次にシリアライザーで自動的に変換されないUserとかのやつを実装
                User tweeteduser = new User();
                string userstring = Regex.Match(result, "(.*?)user\":(.*?),\"(.*?)").Groups[2].Value;
                userstring += "}";
                tweeteduser = JsontoUser(userstring, false);
                if (tweeteduser.profile_image_url_https == null)
                {
                    tweeteduser.UserIcon_normal = user.icon;
                    tweeteduser.name = user.UserName;
                }

                a_tweet.user = tweeteduser;
                tweet.Add(a_tweet);
            }

            return tweet;
        }

        //Twitterから送られてきたJsonデータをUser型に変換
        //flagにはTweetの読み取りを行うかどうか指定
        public static User JsontoUser(string result, bool flag)
        {
            User user = new User();

            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(User));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            stream.Position = 0;
            user = (User)dcjs.ReadObject(stream);

            //プロテクトだけはそのまま読めないので正規表現で読み取ってあげる
            string beta = Regex.Match(result, "(.*?)protected\":(.*?),\"(.*?)").Groups[2].Value;
            if (beta == "true" || beta == "false")
            {
                user.Protected = bool.Parse(beta);
            }
            else if (beta == null)
            {
                user.Protected = false;
            }

            return user;
        }
        public static List<User> JsontoUsers(string result)
        {
            List<User> userlist = new List<User>();


            //処理をしやすくするために最初の文字を消去
            result = result.Remove(0, 1);
            //処理をしやすくするために後ろに適当な文字を入れる
            result += "]";

            StringReader jsonstring = new StringReader(result);
            List<string> userjson = new List<string>();

            //正規表現を用いて },{でテキストを切っていきます
            if (result.Length > 2)
            {
                //初期化
                string[] comparison = new string[3];
                comparison[0] = null;
                comparison[1] = null;
                comparison[2] = null;

                string text = null;
                while (jsonstring.Peek() > -1)
                {
                    comparison[2] = comparison[1];
                    comparison[1] = comparison[0];
                    comparison[0] = Convert.ToString(Convert.ToChar(jsonstring.Read()));
                    text += comparison[2];
                    if (String.Format("{0}{1}{2}", comparison[2], comparison[1], comparison[0]) == "},{")
                    {
                        userjson.Add(text);
                        comparison[1] = null;
                        //リセット
                        text = null;
                    }
                }
            }

            DataContractJsonSerializer dcjs = new DataContractJsonSerializer(typeof(User));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            stream.Position = 0;

            //ツイート1つ1つの処理はこちらから
            for (int i = 0; i < userjson.Count; i++)
            {
                //jsonデータを使える形式に成型します
                string text = null;
                text += userjson[i];
                text += null;

                User user = (User)dcjs.ReadObject(stream);

                //プロテクトだけはそのまま読めないので正規表現で読み取ってあげる
                string beta = Regex.Match(result, "(.*?)protected\":(.*?),\"(.*?)").Groups[2].Value;
                if (beta == "true" || beta == "false")
                {
                    user.Protected = bool.Parse(beta);
                }
                else if (beta == null)
                {
                    user.Protected = false;
                }
                userlist.Add(user);
            }


            return userlist;
        }
    }
    //Object関係
    [DataContract]
    public class Tweet
    {
        [DataMember]
        public string created_at { get; set; }

        public Tweet current_user_retweet;

        public Entity entities;

        [DataMember]
        public int favorite_count { get; set; }
        [DataMember]
        public bool favorited { get; set; }
        //[DataMember]
        public string filter_level { get; set; }

        [DataMember]
        public decimal id { get; set; }
        [DataMember]
        public string id_str { get; set; }

        //[DataMember]
        public string in_reply_to_screen_name { get; set; }
        //[DataMember]
        public decimal in_reply_to_status_id { get; set; }
        //[DataMember]
        public string in_reply_to_status_id_str { get; set; }
        //[DataMember]
        public decimal in_reply_to_user_id { get; set; }
        //[DataMember]
        public string in_reply_to_user_id_str { get; set; }

        //[DataMember]
        public string lang { get; set; }

        public Place place;

        //[DataMember]
        public bool possibly_sensitive { get; set; }

        [DataMember]
        public bool retweeted { get; set; }

        [DataMember]
        public int retweet_count { get; set; }

        public Tweet retweeted_status;

        //[DataMember]
        public string source { get; set; }

        [DataMember]
        public string text { get; set; }
        //[DataMember]
        public bool truncated { get; set; }

        public User user;

        //[DataMember]
        public bool withheld_copyright { get; set; }
        //[DataMember]
        public string[] withheld_in_countries { get; set; }
        //[DataMember]
        public string withheld_scope { get; set; }

    }
    [DataContract]
    public class User
    {
        //[DataMember]
        public string contributors_enabled { get; set; }
        [DataMember]
        public string created_at { get; set; }

        //[DataMember]
        public bool default_profile { get; set; }
        //[DataMember]
        public bool default_profile_image { get; set; }

        //[DataMember]
        public string description { get; set; }

        //[DataMember]
        public Entity entities;

        [DataMember]
        public int favourites_count { get; set; }

        //DataMember]
        public bool follow_request_sent { get; set; }
        //[DataMember]
        public bool following { get; set; }

        //[DataMember]
        public int followers_count { get; set; }
        [DataMember]
        public int friends_count { get; set; }
        //[DataMember]
        public bool geo_enabled { get; set; }

        [DataMember]
        public decimal id { get; set; }
        [DataMember]
        public string id_str { get; set; }

        //bigger=個人ページ用,normal=TL表示用,mini=ふぁぼ表示用
        public Image UserIcon_bigger;
        public Image UserIcon_normal;
        public Image UserIcon_mini;

        public Image Bannerweb;

        //[DataMember]
        public bool is_translator { get; set; }
        //[DataMember]
        public string lang { get; set; }
        //[DataMember]
        public int listed_count { get; set; }
        //[DataMember]
        public string location { get; set; }
        [DataMember]
        public string name { get; set; }

        //[DataMember]
        public string profile_background_color { get; set; }
        //[DataMember]
        public string profile_background_image_url { get; set; }
        //[DataMember]
        public string profile_background_image_url_https { get; set; }
        //[DataMember]
        public bool profile_background_tile { get; set; }
        //[DataMember]
        public string profile_banner_url { get; set; }

        [DataMember]
        public string profile_image_url { get; set; }
        [DataMember]
        public string profile_image_url_https { get; set; }
        [DataMember]
        public string profile_icon_url { get; set; }

        //[DataMember]
        public string profile_link_color { get; set; }
        //[DataMember]
        public string profile_sidebar_border_color { get; set; }
        //[DataMember]
        public string profile_sidebar_fill_color { get; set; }
        //[DataMember]
        public string profile_text_color { get; set; }
        //[DataMember]
        public bool profile_use_background_image { get; set; }

        public bool Protected { get; set; }

        [DataMember]
        public string screen_name { get; set; }

        //[DataMember]
        public bool show_all_inline_media { get; set; }

        public Tweet status;

        //[DataMember]
        public int statuses_count { get; set; }

        //[DataMember]
        public string time_zone { get; set; }

        [DataMember]
        public string url { get; set; }

        //[DataMember]
        public int utc_offset { get; set; }

        //[DataMember]
        public bool verified { get; set; }


        //[DataMember]
        public string withheld_in_countries { get; set; }
        //[DataMember]
        public string withheld_scope { get; set; }

    }

    public class Entity
    { }
    public class Entity_in_Object
    { }
    public class Place
    { }
    public class OAuth
    {
        private static string ConsumerKey { get { return ""; } }
        private static string ConsumerSecret { get { return ""; } }

        private string RequestKey { get; set; }
        private string RequestSecret { get; set; }

        private string AccessKey { get; set; }
        private string AccessSecret { get; set; }
        public string UserId { get; set; }
        public string ScreenName { get; set; }

        //付随情報
        public Image icon { get; set; }
        public string UserName { get; set; }

        public string PostUrl { get; set; }
        public string[] PostString { get; set; }

        public async Task<string[]> GetRequesttoken()
        {
            string APIURL = "https://api.twitter.com/oauth/request_token";

            var keys = new SortedDictionary<string, string>()
            {
                {"oauth_nonce",GenerateNonce()},
                {"oauth_callback","oob"},
                {"oauth_signature_method","HMAC-SHA1"},
                {"oauth_timestamp",GenerateTimeStamp()},
                {"oauth_consumer_key",ConsumerKey},
                {"oauth_version", "1.0"}
            };

            string signature = GenerateSignature(APIURL, HttpMethod.Post, ConsumerSecret, AccessSecret, keys);
            keys.Add("oauth_signature", signature);

            string RequestURL = "https://api.twitter.com/oauth/request_token?";
            string AuthorizationParms = null;

            foreach (string key in keys.Keys)
            {
                RequestURL += key + "=" + WebUtility.UrlEncode(keys[key]) + "&";
                AuthorizationParms += key + "=\"" + keys[key] + "\", ";
            }
            RequestURL = RequestURL.Remove(RequestURL.Length - 1);
            AuthorizationParms = AuthorizationParms.Remove(AuthorizationParms.Length - 2, 2);

            var request = new HttpRequestMessage();
            var response = new HttpResponseMessage();
            var client = new HttpClient();

            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(RequestURL);
            request.Headers.Authorization = new AuthenticationHeaderValue("OAuth", AuthorizationParms);

            request.Content = null;


            string result = null;

            response = await client.SendAsync(request);
            var test = request.Headers.AcceptEncoding.ToString();
            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                string[] alternative = await GetRequesttoken();
                return alternative;
            }
            byte[] data = await response.Content.ReadAsByteArrayAsync();


            //16/4/22UWP移行に伴いGzipの解凍を行います
            result = defreezegzip(data);


            RequestKey = Regex.Match(result, @"oauth_token=(.*?)&oauth_token_secret=.*?&oauth_callback.*").Groups[1].Value;
            RequestSecret = Regex.Match(result, @"oauth_token=(.*?)&oauth_token_secret=(.*?)&oauth_callback.*").Groups[2].Value;

            var returnresult = new string[3];
            returnresult[0] = PostUrl;
            returnresult[1] = RequestKey;
            returnresult[2] = RequestSecret;
            PostString = returnresult;
            return returnresult;
        }
        public async Task GetAccessKey(string PIN)
        {
            const string APIURL = "https://api.twitter.com/oauth/access_token";
            string ACSURL = "https://api.twitter.com/oauth/access_token?";

            var postdata = new SortedDictionary<string, string>
            {
                {"oauth_consumer_key",ConsumerKey},
                {"oauth_nonce",GenerateNonce()},
                {"oauth_signature_method","HMAC-SHA1"},
                {"oauth_timestamp",GenerateTimeStamp()},
                {"oauth_token",RequestKey},
                {"oauth_version","1.0"},
                {"oauth_verifier",PIN}
            };

            string signature = GenerateSignature(APIURL, HttpMethod.Post, ConsumerSecret, RequestSecret, postdata);
            postdata.Add("oauth_signature", WebUtility.UrlEncode(signature));

            var postquery = new Dictionary<string, string>
            {
                {"oauth_consumer_key",ConsumerKey},
                {"oauth_nonce",postdata["oauth_nonce"]},
                {"oauth_signature_method","HMAC-SHA1"},
                {"oauth_timestamp",postdata["oauth_timestamp"]},
                {"oauth_token",RequestKey},
                {"oauth_version","1.0"},
                {"oauth_signature",WebUtility.UrlEncode(signature)},
                {"oauth_verifier",PIN}
            };

            foreach (string key in postquery.Keys)
            {
                ACSURL += key + "=" + postquery[key] + "&";
            }
            ACSURL = ACSURL.Remove(ACSURL.Length - 1);

            var content = new FormUrlEncodedContent(postdata);
            var request = new HttpRequestMessage(HttpMethod.Post, ACSURL);
            request.Content = content;
            var response = new HttpResponseMessage();
            var client = new System.Net.Http.HttpClient();
            string result = null;

            response = await client.SendAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                byte[] data = await response.Content.ReadAsByteArrayAsync();


                //16/4/22UWP移行に伴いGzipの解凍を行います
                using (MemoryStream ms = new MemoryStream())
                {

                    byte[] gzBuffer = data;
                    int mslength = BitConverter.ToInt32(gzBuffer, 0);
                    ms.Write(gzBuffer, 0, gzBuffer.Length - 0);
                    byte[] Buffer = new byte[mslength];
                    ms.Position = 0;
                    using (System.IO.Compression.GZipStream zip = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Decompress))
                    {
                        zip.Read(Buffer, 0, Buffer.Length);
                    }
                    result = Encoding.UTF8.GetString(Buffer, 0, Buffer.Length);
                }
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                var dialog = new MessageDialog("Twitterアプリ認証に失敗しました再度読み込んでください", "権限が取得できませんでした");
                await dialog.ShowAsync();
            }
            result += "🍸";
            
            AccessKey = Regex.Match(result, @"oauth_token=(.*?)&oauth_token_secret=(.*?)&user_id=(.*?)&screen_name=(.*?)🍸(.*?)").Groups[1].Value;
            AccessSecret = Regex.Match(result, @"oauth_token=(.*?)&oauth_token_secret=(.*?)&user_id=(.*?)&screen_name=(.*?)🍸(.*?)").Groups[2].Value;
            UserId = Regex.Match(result, @"oauth_token=(.*?)&oauth_token_secret=(.*?)&user_id=(.*?)&screen_name=(.*?)🍸(.*?)").Groups[3].Value;
            ScreenName = Regex.Match(result, @"oauth_token=(.*?)&oauth_token_secret=(.*?)&user_id=(.*?)&screen_name=(.*?)&x(.*?)").Groups[4].Value;

        }



        public async Task<string> RestGET(OAuth oauth, string APIURL, SortedDictionary<string, string> postdata)
        {

            var Header = HeaderCreate(APIURL, oauth, HttpMethod.Get, postdata);
            string posturl = APIURL + "?";

            string authorizationHeaderParams = null;

            foreach (string key in Header.Keys)
            {
                posturl += key + "=" + Header[key] + "&";
                authorizationHeaderParams += key + "=\"" + Header[key] + "\", ";
            }
            posturl = posturl.Remove(posturl.Length - 1);
            authorizationHeaderParams = authorizationHeaderParams.Remove(authorizationHeaderParams.Length - 2);

            var request = new HttpRequestMessage();

            var client = new HttpClient();
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri(posturl);
            request.Headers.Host = "api.twitter.com";
            request.Headers.Authorization = new AuthenticationHeaderValue("OAuth", authorizationHeaderParams);

            var response = await client.SendAsync(request);
            byte[] data = await response.Content.ReadAsByteArrayAsync();

            return defreezegzip(data);
        }
        public async Task<string> RestPOST(OAuth oauth, string APIURL, SortedDictionary<string, string> postdata)
        {
            var postquery = new Dictionary<string, string>(postdata);

            SortedDictionary<string, string> Header = HeaderCreate(APIURL, oauth, HttpMethod.Post, postdata);
            string posturl = APIURL + "?";

            //最初に送るべきパラメーターを追加してからoauth関連のパラメーターを入れる
            postquery.Add("oauth_consumer_key", ConsumerKey);
            postquery.Add("oauth_nonce", Header["oauth_nonce"]);
            postquery.Add("oauth_timestamp", Header["oauth_timestamp"]);
            postquery.Add("oauth_token", oauth.AccessKey);
            postquery.Add("oauth_signature_method", "HMAC-SHA1");
            postquery.Add("oauth_version", "1.0");
            postquery.Add("oauth_signature", Header["oauth_signature"]);

            string authorizationHeaderParams = null;

            foreach (string key in postquery.Keys)
            {
                posturl += key + "=" + postquery[key] + "&";
                authorizationHeaderParams += key + "=\"" + postquery[key] + "\", ";
            }
            posturl = posturl.Remove(posturl.Length - 1);
            authorizationHeaderParams = authorizationHeaderParams.Remove(authorizationHeaderParams.Length - 2);

            var request = new HttpRequestMessage();

            var client = new HttpClient();
            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(posturl);
            request.Headers.Host = "api.twitter.com";
            request.Headers.Authorization = new AuthenticationHeaderValue("OAuth", authorizationHeaderParams);
            var response = await client.SendAsync(request);
            byte[] data = await response.Content.ReadAsByteArrayAsync();

            return defreezegzip(data);

        }

        //16/4/22に追加gzipの解凍関数
        private string defreezegzip(byte[] data)
        {
            string result = null;
            //16/4/22UWP移行に伴いGzipの解凍を行います
            using (MemoryStream ms = new MemoryStream())
            {

                byte[] gzBuffer = data;
                int mslength = BitConverter.ToInt32(gzBuffer, 0);
                ms.Write(gzBuffer, 0, gzBuffer.Length - 0);
                byte[] Buffer = new byte[mslength];
                ms.Position = 0;
                using (System.IO.Compression.GZipStream zip = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Decompress))
                {
                    zip.Read(Buffer, 0, Buffer.Length);
                }
                result = Encoding.UTF8.GetString(Buffer, 0, Buffer.Length);
            }
            return result;
        }

        //ストリーミングに接続
        public async Task<HttpResponseMessage> StreamGet(OAuth oauth, string APIURL, SortedDictionary<string, string> postdata)
        {
            SortedDictionary<string, string> Header = HeaderCreate(APIURL, oauth, HttpMethod.Get, postdata);
            string posturl = APIURL + "?";

            string authorizationHeaderParams = null;

            foreach (string key in Header.Keys)
            {
                posturl += key + "=" + Header[key] + "&";
                authorizationHeaderParams += key + "=\"" + Header[key] + "\", ";
            }
            posturl = posturl.Remove(posturl.Length - 1);
            authorizationHeaderParams = authorizationHeaderParams.Remove(authorizationHeaderParams.Length - 2);

            var request = new HttpRequestMessage();
            var client = new HttpClient();
            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri(posturl);
            request.Headers.Authorization = new AuthenticationHeaderValue("OAuth", authorizationHeaderParams);

            client.Timeout = System.Threading.Timeout.InfiniteTimeSpan;

            HttpResponseMessage res = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            return res;
        }

        //テンプレ通り
        public static string GenerateTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        public static string GenerateNonce()
        {
            Random random = new Random();
            string strings = "0123456789abcdefghijklmnopqrstuvwxyABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string res = "";
            for (int i = 0; i < 32; i++)
                res += strings[random.Next(0, strings.Length - 1)];
            return res;
        }

        public static string GenerateSignature(string APIURL, HttpMethod type, string ConsumerSecret, string AccessSecret, SortedDictionary<string, string> parms)
        {
            string key = ConsumerSecret + "&" + AccessSecret;

            string data = null;
            foreach (string keys in parms.Keys)
            {
                data += WebUtility.UrlEncode(keys) + "=" + WebUtility.UrlEncode(parms[keys]) + "&";
            }
            data = data.Remove(data.Length - 1);
            data = WebUtility.UrlEncode(data);
            string URL = WebUtility.UrlEncode(APIURL);
            data = type.ToString() + "&" + URL + "&" + data;

            var KeyMaterial = CryptographicBuffer.ConvertStringToBinary(key, BinaryStringEncoding.Utf8);
            var Converter = MacAlgorithmProvider.OpenAlgorithm("HMAC_SHA1");
            var MacKey = Converter.CreateKey(KeyMaterial);

            var DataToBeSigned = CryptographicBuffer.ConvertStringToBinary(data, BinaryStringEncoding.Utf8);
            var SignBuffer = CryptographicEngine.Sign(MacKey, DataToBeSigned);

            string signature = CryptographicBuffer.EncodeToBase64String(SignBuffer);
            return signature;
        }
        public static string GenerateSignature(string APIURL, OAuth oauth, HttpMethod Method, SortedDictionary<string, string> postdata)
        {
            Uri url = new Uri(APIURL);
            string normalizedRequestParameters = null;

            string nonce = GenerateNonce();
            string timestamp = GenerateTimeStamp();

            SortedDictionary<string, string> parameters = postdata;
            parameters.Add("oauth_version", "1.0");
            parameters.Add("oauth_nonce", nonce);
            parameters.Add("oauth_timestamp", timestamp);
            parameters.Add("oauth_signature_method", "HMAC-SHA1");
            parameters.Add("oauth_consumer_key", ConsumerKey);
            parameters.Add("oauth_token", oauth.AccessKey);

            foreach (string key in parameters.Keys)
            {
                normalizedRequestParameters += key + "=" + parameters[key] + "&";
            }
            normalizedRequestParameters = normalizedRequestParameters.Remove(normalizedRequestParameters.Length - 1);

            string SignatureBase = Method.ToString() + "&" + WebUtility.UrlEncode(APIURL) + "&" + WebUtility.UrlEncode(normalizedRequestParameters);

            string Key = WebUtility.UrlEncode(ConsumerSecret) + "&" + WebUtility.UrlEncode(oauth.AccessSecret);

            var KeyMaterial = CryptographicBuffer.ConvertStringToBinary(Key, BinaryStringEncoding.Utf8);
            var Converter = MacAlgorithmProvider.OpenAlgorithm("HMAC_SHA1");
            var MacKey = Converter.CreateKey(KeyMaterial);

            var DataToBeSigned = CryptographicBuffer.ConvertStringToBinary(SignatureBase, BinaryStringEncoding.Utf8);
            var SignBuffer = CryptographicEngine.Sign(MacKey, DataToBeSigned);

            string signature = CryptographicBuffer.EncodeToBase64String(SignBuffer);
            return signature;
        }

        public static SortedDictionary<string, string> HeaderCreate(string APIURL, OAuth oauth, HttpMethod Method, SortedDictionary<string, string> postdata)
        {
            Uri url = new Uri(APIURL);
            string normalizedUrl = APIURL;
            string normalizedRequestParameters = null;

            string nonce = GenerateNonce();
            string timestamp = GenerateTimeStamp();

            SortedDictionary<string, string> parameters = postdata;
            parameters.Add("oauth_consumer_key", ConsumerKey);
            parameters.Add("oauth_token", oauth.AccessKey);
            parameters.Add("oauth_nonce", nonce);
            parameters.Add("oauth_timestamp", timestamp);
            parameters.Add("oauth_version", "1.0");
            parameters.Add("oauth_signature_method", "HMAC-SHA1");

            foreach (string key in parameters.Keys)
            {
                normalizedRequestParameters += key + "=" + parameters[key] + "&";
            }
            normalizedRequestParameters = normalizedRequestParameters.Remove(normalizedRequestParameters.Length - 1);

            StringBuilder signatureBase = new StringBuilder();
            signatureBase.AppendFormat("{0}&", Method.ToString());
            signatureBase.AppendFormat("{0}&", WebUtility.UrlEncode(normalizedUrl));
            signatureBase.AppendFormat("{0}", WebUtility.UrlEncode(normalizedRequestParameters));
            string SignatureBase = signatureBase.ToString();


            string Key = string.Format("{0}&{1}", WebUtility.UrlEncode(ConsumerSecret), WebUtility.UrlEncode(oauth.AccessSecret));

            var crypt = MacAlgorithmProvider.OpenAlgorithm("HMAC_SHA1");
            var keyBuffer = CryptographicBuffer.CreateFromByteArray(Encoding.UTF8.GetBytes(Key));
            var cryptKey = crypt.CreateKey(keyBuffer);

            var dataBuffer = CryptographicBuffer.CreateFromByteArray(Encoding.UTF8.GetBytes(SignatureBase));
            var signBuffer = CryptographicEngine.Sign(cryptKey, dataBuffer);

            byte[] value;
            CryptographicBuffer.CopyToByteArray(signBuffer, out value);

            string signature = Convert.ToBase64String(value);
            signature = WebUtility.UrlEncode(signature);
            parameters.Add("oauth_signature", signature);
            return parameters;
        }




    }

}
