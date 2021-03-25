using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalR.Server.Hubs
{
    public class WordGeneratorHub : Hub
    {
        static List<String> lsWords = new List<string>();
        private volatile bool _commandRunning = false;
        static int _commandTimeRemaining = 0;
        private readonly object _updatewordLock = new object();

        IHubContext<WordGeneratorHub> _hubContext = null;

        public WordGeneratorHub(IHubContext<WordGeneratorHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public int GetCommandTimeRemaining()
        {
            return _commandTimeRemaining;
        }

        public bool GetCommandRunning()
        {
            return _commandRunning;
        }

        public void AddWord(String word)
        {
            lsWords.Add(word);
        }

        public void start()
        {
            lsWords = ShuffleList(lsWords);
            BroadcastWords();
           
        }

        private void BroadcastWords()
        {
            lock (_updatewordLock)
            {
                if (!_commandRunning && lsWords.Count() > 0)
                {
                    _commandRunning = true;

                    int wordWaitDuration = 60000/ lsWords.Count();
                    _commandTimeRemaining = wordWaitDuration;

                    foreach (var word in lsWords)
                    {
                        Thread.Sleep(wordWaitDuration);
                        BroadcastWord(word);
                        _commandTimeRemaining = _commandTimeRemaining - wordWaitDuration;
                    }
                    lsWords.Clear();
                    _commandTimeRemaining = 0;
                    _commandRunning = false;
                }
            }
        }

        private void BroadcastWord(String word)
        {
            _hubContext.Clients.All.SendAsync("CurrentWordSelected", word);
        }

        private List<E> ShuffleList<E>(List<E> inputList)
        {
            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }

        public static void Randomize<T>(T[] items)
        {
            Random rand = new Random();

            // For each spot in the array, pick
            // a random item to swap into that spot.
            for (int i = 0; i < items.Length - 1; i++)
            {
                int j = rand.Next(i, items.Length);
                T temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }

    }
}
