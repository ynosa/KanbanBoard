

namespace KanbanBoard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public static class MonadExtensions
    {
        /// <summary>
        /// Withes the specified input.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="input">The input.</param>
        /// <param name="evaluator">The evaluator.</param>
        /// <returns>Result</returns>
        public static TResult With<TInput, TResult>(this TInput input, Func<TInput, TResult> evaluator)
        {
            
            if (input == null)
            {
                return default(TResult);
            }

            return evaluator(input);
        }

        /// <summary>
        /// Withes the specified input.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <param name="input">The input.</param>
        /// <param name="evaluator">The evaluator.</param>
        /// <returns>
        /// Result
        /// </returns>
        public static TInput WithNull<TInput>(this TInput input, Func<TInput> evaluator)
        {
            if (input == null)
            {
                return evaluator();
            }

            return input;
        }

        /// <summary>
        /// Returns the specified input.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="input">The input.</param>
        /// <param name="evaluator">The evaluator.</param>
        /// <param name="failureValue">The failure value.</param>
        /// <returns>Result</returns>
        public static TResult Return<TInput, TResult>(this TInput input, Func<TInput, TResult> evaluator, TResult failureValue)
        {            
            if (input == null)
            {
                return failureValue;
            }

            return evaluator(input);
        }

        /// <summary>
        /// Ifs the specified input.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <param name="input">The input.</param>
        /// <param name="evaluator">The evaluator.</param>
        /// <returns>Result</returns>
        public static TInput If<TInput>(this TInput input, Func<TInput, bool> evaluator)
        {            
            if (input == null)
            {
                return default(TInput);
            }

            return evaluator(input) ? input : default(TInput);
        }

        /// <summary>
        /// Unlesses the specified input.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <param name="input">The input.</param>
        /// <param name="evaluator">The evaluator.</param>
        /// <returns>Result</returns>
        public static TInput Unless<TInput>(this TInput input, Func<TInput, bool> evaluator)
        {            
            if (input == null)
            {
                return default(TInput);
            }

            return evaluator(input) ? default(TInput) : input;
        }

        /// <summary>
        /// Does the specified input.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <param name="input">The input.</param>
        /// <param name="action">The action.</param>
        /// <returns>
        /// Result
        /// </returns>
        public static TInput Do<TInput>(this TInput input, Action<TInput> action)
        {            
            if (input == null)
            {
                return default(TInput);
            }

            action(input);

            return input;
        }

        /// <summary>
        /// Does the specified input.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <param name="input">The input.</param>
        /// <param name="action">The action.</param>
        /// <returns>
        /// Result
        /// </returns>
        public static TInput Null<TInput>(this TInput input, Action action)
        {            
            if (input == null)
            {
                action();
            }

            return input;
        }

        /// <summary>
        /// Does the specified input.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <param name="input">The input.</param>
        /// <param name="action">The action.</param>
        /// <param name="defaultValue"> </param>
        /// <returns>
        /// Result
        /// </returns>
        public static TInput Null<TInput>(this TInput input, TInput defaultValue)
        {
            if (input == null)
            {
                return defaultValue;
            }

            return input;
        }

        /// <summary>
        /// Does the specified input.
        /// </summary>
        /// <typeparam name="TInput">The type of the input.</typeparam>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="input">The input.</param>
        /// <param name="exception">The exception.</param>
        /// <returns>
        /// Result
        /// </returns>
        public static TInput NullException<TInput, TException>(this TInput input, TException exception)
            where TException : Exception
        {        
            if (input == null)
            {
                throw exception;
            }

            return input;
        }
    }
}
