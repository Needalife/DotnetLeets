namespace DotnetLeets.Core
{
    internal static class TestHelper
    {
        public static void Test<TInput, TOutput>(
            TInput input,
            TOutput expected,
            Func<TInput, TOutput> solver,
            Func<TOutput, TOutput, bool>? comparer = null)
        {
            Console.WriteLine($"Input: {FormatValue(input)}");

            var output = solver(input);

            comparer ??= AreEqual;

            PrintResult(output, expected, comparer);
        }

        public static void Test<TInput1, TInput2, TOutput>(
            TInput1 input1,
            TInput2 input2,
            TOutput expected,
            Func<TInput1, TInput2, TOutput> solver,
            Func<TOutput, TOutput, bool>? comparer = null)
        {
            Console.WriteLine("Input:");

            Console.WriteLine($"input1 = {FormatValue(input1)}");
            Console.WriteLine($"input2 = {FormatValue(input2)}");

            var output = solver(input1, input2);

            comparer ??= AreEqual;

            PrintResult(output, expected, comparer);
        }

        public static void TestAllCases<TInput, TOutput>(
            Dictionary<TInput, TOutput> testCases,
            Func<TInput, TOutput> solver,
            Func<TOutput, TOutput, bool>? comparer = null)
        {
            foreach (var testCase in testCases)
            {
                Test(
                    testCase.Key,
                    testCase.Value,
                    solver,
                    comparer);
            }
        }
        
        public static void TestAllCases<TInput1, TInput2, TOutput>(
            List<((TInput1, TInput2) input, TOutput expected)> testCases,
            Func<TInput1, TInput2, TOutput> solver,
            Func<TOutput, TOutput, bool>? comparer = null)
        {
            foreach (var testCase in testCases)
            {
                Test(
                    testCase.input.Item1,
                    testCase.input.Item2,
                    testCase.expected,
                    solver,
                    comparer);
            }
        }

        private static void PrintResult<TOutput>(
            TOutput output,
            TOutput expected,
            Func<TOutput, TOutput, bool>? comparer = null)
        {
            Console.WriteLine($"\nExpected: {FormatValue(expected)}");
            Console.WriteLine($"Output: {FormatValue(output)}\n");

            Console.WriteLine(
                comparer(output, expected)
                    ? "[PASS]"
                    : "[FAIL]");

            Console.WriteLine("\n-------------------\n");
        }

        private static bool AreEqual<T>(T output, T expected)
        {
            if (output is System.Collections.IEnumerable outputEnum &&
                expected is System.Collections.IEnumerable expectedEnum &&
                output is not string)
            {
                return outputEnum.Cast<object>()
                    .SequenceEqual(expectedEnum.Cast<object>());
            }

            return EqualityComparer<T>.Default.Equals(output, expected);
        }

        private static string FormatValue(object? value)
        {
            if (value == null)
            {
                return "null";
            }

            if (value is string str)
            {
                return str;
            }

            if (value is System.Collections.IEnumerable enumerable)
            {
                var items = enumerable
                    .Cast<object>()
                    .Select(FormatValue);

                return $"[{string.Join(", ", items)}]";
            }

            return value.ToString() ?? "null";
        }
    }
}