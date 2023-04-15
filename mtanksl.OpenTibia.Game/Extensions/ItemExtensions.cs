﻿using OpenTibia.Common.Objects;
using OpenTibia.Game.Commands;
using System;

namespace OpenTibia.Game.Extensions
{
    public static class ItemExtensions
    {
        /// <exception cref="InvalidOperationException"></exception>

        public static Promise DecayDestroy(this Item item, int executeInMilliseconds)
        {
            Context context = Context.Current;

            if (context == null)
            {
                throw new InvalidOperationException("Context not found.");
            }

            return context.AddCommand(new ItemDecayDestroyCommand(item, executeInMilliseconds) );
        }

        /// <exception cref="InvalidOperationException"></exception>

        public static PromiseResult<Item> DecayTransform(this Item item, int executeInMilliseconds, ushort openTibiaId, byte count)
        {
            Context context = Context.Current;

            if (context == null)
            {
                throw new InvalidOperationException("Context not found.");
            }

            return context.AddCommand(new ItemDecayTransformCommand(item, executeInMilliseconds, openTibiaId, count) );
        }

        /// <exception cref="InvalidOperationException"></exception>

        public static Promise Decrement(this Item item, byte count)
        {
            Context context = Context.Current;

            if (context == null)
            {
                throw new InvalidOperationException("Context not found.");
            }

            return context.AddCommand(new ItemDecrementCommand(item, count) );
        }

        /// <exception cref="InvalidOperationException"></exception>

        public static Promise Destroy(this Item item)
        {
            Context context = Context.Current;

            if (context == null)
            {
                throw new InvalidOperationException("Context not found.");
            }

            return context.AddCommand(new ItemDestroyCommand(item) );
        }

        /// <exception cref="InvalidOperationException"></exception>

        public static PromiseResult<Item> Transform(this Item item, ushort openTibiaId, byte count)
        {
            Context context = Context.Current;

            if (context == null)
            {
                throw new InvalidOperationException("Context not found.");
            }

            return context.AddCommand(new ItemTransformCommand(item, openTibiaId, count) );
        }
    }
}