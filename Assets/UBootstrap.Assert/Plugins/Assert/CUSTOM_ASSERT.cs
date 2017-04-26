using System.Text;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace UBootstrap
{
    /// <summary>
    /// A custom assertion class to be used in your project in lieu of Unity's Assertions.Assert
    /// Each project should extend this class and define your own sets of error code
    /// </summary>
    public partial class CUSTOM_ASSERT
    {
        private static readonly StringBuilder stringBuilder = new StringBuilder ();
        private const string CodePrefix = "Code:{0}";
        private const string MessagePrefix = " Message:";
        private const float Epsilon = 0.00001f;

        /// <summary>
        /// Assert that condition is true, otherwise throw Exception with the specified arguments.
        /// </summary>
        /// <param name="condition">If set to <c>true</c> condition.</param>
        /// <param name="errorCode">Error code.</param>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        [System.Diagnostics.Conditional ("CUSTOM_ASSERT")]
        static public void IsTrue (bool condition, int errorCode, string message = "", params object[] args)
        {
            if (!condition) {
                stringBuilder.Remove (0, stringBuilder.Length);
                stringBuilder.AppendFormat (CodePrefix, errorCode.ToString ());
                stringBuilder.AppendFormat (MessagePrefix);
                stringBuilder.AppendFormat (message, args);
                throw new Exception (stringBuilder.ToString ());
            }
        }

        /// <summary>
        /// Assert that condition is false, otherwise throw Exception with the specified arguments.
        /// </summary>
        /// <param name="condition">If set to <c>true</c> condition.</param>
        /// <param name="errorCode">Error code.</param>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        [System.Diagnostics.Conditional ("CUSTOM_ASSERT")]
        static public void IsFalse (bool condition, int errorCode, string message = "", params object[] args)
        {
            IsTrue (!condition, errorCode, message, args);
        }

        /// <summary>
        /// Assert that value is null.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="errorCode">Error code.</param>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        [System.Diagnostics.Conditional ("CUSTOM_ASSERT")]
        static public void IsNull (object value, int errorCode, string message = "", params object[] args)
        {
            IsTrue (value == null || value.Equals (null), errorCode, message, args);
        }

        /// <summary>
        /// Assert that value is not null.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="errorCode">Error code.</param>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        [System.Diagnostics.Conditional ("CUSTOM_ASSERT")]
        static public void IsNotNull (object value, int errorCode, string message = "", params object[] args)
        {
            IsFalse (value == null || value.Equals (null), errorCode, message, args);
        }

        /// <summary>
        /// Assert that expected and actual are equal.
        /// </summary>
        /// <param name="expected">Expected.</param>
        /// <param name="actual">Actual.</param>
        /// <param name="errorCode">Error code.</param>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        [System.Diagnostics.Conditional ("CUSTOM_ASSERT")]
        static public void AreEqual<T> (T expected, T actual, int errorCode, string message = "", params object[] args)
        {
            IsTrue (expected.Equals (actual), errorCode, message, args);
        }

        /// <summary>
        /// Assert that expected and actual are equal with optional custom comparer.
        /// </summary>
        /// <param name="expected">Expected.</param>
        /// <param name="actual">Actual.</param>
        /// <param name="errorCode">Error code.</param>
        /// <param name="comparer">Comparer.</param>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        [System.Diagnostics.Conditional ("CUSTOM_ASSERT")]
        static public void AreEqual<T> (T expected, T actual, int errorCode, IEqualityComparer<T> comparer, string message = "", params object[] args)
        {
            IsTrue (comparer.Equals (expected, actual), errorCode, message, args);
        }

        /// <summary>
        /// Assert that expected and actual are not equal.
        /// </summary>
        /// <param name="expected">Expected.</param>
        /// <param name="actual">Actual.</param>
        /// <param name="errorCode">Error code.</param>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        [System.Diagnostics.Conditional ("CUSTOM_ASSERT")]
        static public void AreNotEqual<T> (T expected, T actual, int errorCode, string message = "", params object[] args)
        {
            IsFalse (expected.Equals (actual), errorCode, message, args);
        }

        /// <summary>
        /// Assert that expected and actual are not equal with optional custom comparer
        /// </summary>
        /// <param name="expected">Expected.</param>
        /// <param name="actual">Actual.</param>
        /// <param name="errorCode">Error code.</param>
        /// <param name="comparer">Comparer.</param>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        [System.Diagnostics.Conditional ("CUSTOM_ASSERT")]
        static public void AreNotEqual<T> (T expected, T actual, int errorCode, IEqualityComparer<T> comparer, string message = "", params object[] args)
        {
            IsFalse (comparer.Equals (expected, actual), errorCode, message, args);
        }

        /// <summary>
        /// Asserts that the values are approximately equal. An absolute error check is used for 
        /// approximate equality check (|a-b| < tolerance). Default tolerance is 0.00001f.
        /// <param name="expected">Expected.</param>
        /// <param name="actual">Actual.</param>
        /// <param name="errorCode">Error code.</param>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        [System.Diagnostics.Conditional ("CUSTOM_ASSERT")]
        static public void AreApproximatelyEqual (float expected, float actual, int errorCode, string message = "", params object[] args)
        {
            AreApproximatelyEqual (expected, actual, errorCode, Epsilon, message, args);
        }

        /// <summary>
        /// Asserts that the values are approximately equal. An absolute error check is used for 
        /// approximate equality check (|a-b| < tolerance)
        /// </summary>
        /// <param name="expected">Expected.</param>
        /// <param name="actual">Actual.</param>
        /// <param name="errorCode">Error code.</param>
        /// <param name="tolerance">Tolerance.</param>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        [System.Diagnostics.Conditional ("CUSTOM_ASSERT")]
        static public void AreApproximatelyEqual (float expected, float actual, int errorCode, float tolerance, string message = "", params object[] args)
        {
            IsTrue (Mathf.Abs (expected - actual) < tolerance, errorCode, message, args);
        }

        /// <summary>
        /// Asserts that the values are NOT approximately equal. An absolute error check is used for 
        /// approximate equality check (|a-b| < tolerance). Default tolerance is 0.00001f.
        /// </summary>
        /// <param name="expected">Expected.</param>
        /// <param name="actual">Actual.</param>
        /// <param name="errorCode">Error code.</param>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        [System.Diagnostics.Conditional ("CUSTOM_ASSERT")]
        static public void AreNotApproximatelyEqual (float expected, float actual, int errorCode, string message = "", params object[] args)
        {
            AreNotApproximatelyEqual (expected, actual, errorCode, Epsilon, message, args);
        }

        /// <summary>
        /// Asserts that the values are NOT approximately equal. An absolute error check is used for 
        /// approximate equality check (|a-b| < tolerance)
        /// </summary>
        /// <param name="expected">Expected.</param>
        /// <param name="actual">Actual.</param>
        /// <param name="errorCode">Error code.</param>
        /// <param name="tolerance">Tolerance.</param>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        [System.Diagnostics.Conditional ("CUSTOM_ASSERT")]
        static public void AreNotApproximatelyEqual (float expected, float actual, int errorCode, float tolerance, string message = "", params object[] args)
        {
            IsTrue (Mathf.Abs (expected - actual) >= tolerance, errorCode, message, args);
        }

        /// <summary>
        /// Fail the assertion.
        /// </summary>
        /// <param name="errorCode">Error code.</param>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        /// [System.Diagnostics.Conditional ("CUSTOM_ASSERT")]
        static public void Fail (int errorCode, string message = "", params object[] args)
        {
            IsTrue (false, errorCode, message, args);
        }

    }

}
