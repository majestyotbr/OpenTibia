﻿using System;
using System.Linq;

namespace OpenTibia.Game
{
    public class Randomization
    {
        private Random random = new Random();

        /// <exception cref="ArgumentException"></exception>

        public int Take(int minInclusive, int maxInclusive)
        {
            if (minInclusive < 0)
            {
                throw new ArgumentException("MinInclusive must be greater then or equals to 0.");
            }

            if (maxInclusive < minInclusive)
            {
                throw new ArgumentException("MaxInclusive must be greater then or equals to MinInclusive.");
            }

            if (minInclusive == maxInclusive)
            {
                return minInclusive;
            }

            return random.Next(minInclusive, maxInclusive + 1);
        }

        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>

        public T Take<T>(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array) );
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Array must have at least one item.");
            }

            return array[ random.Next(0, array.Length) ];
        }

        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>

        public T Take<T>(T[] array, int[] weights)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array) );
            }

            if (weights == null)
            {
                throw new ArgumentNullException(nameof(weights) );
            }

            if (array.Length == 0)
            {
                throw new ArgumentException("Array must have at least one item.");
            }

            if (array.Length != weights.Length)
            {
                throw new ArgumentException("Array must have the same length of Weights.");
            }

            int value = random.Next(0, weights.Sum() );

            for (int i = 0; i < array.Length; i++)
            {
                if (value < weights[i] )
                {
                    return array[i];
                }

                value -= weights[i];
            }

            throw new NotImplementedException();
        }

        /// <exception cref="ArgumentNullException"></exception>

        public T[] Shuffle<T>(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array) );
            }

            int currentIndex = array.Length - 1;

            while (currentIndex > 0)
            {
                int newIndex = random.Next(0, currentIndex + 1);

                if (currentIndex != newIndex)
                {
                    T temp = array[currentIndex]; array[currentIndex] = array[newIndex]; array[newIndex] = temp;
                }

                currentIndex--;
            }

            return array;
        }
    }
}