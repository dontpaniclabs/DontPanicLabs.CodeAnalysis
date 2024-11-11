// Licensed to the.NET Foundation under one or more agreements.
// The.NET Foundation licenses this file to you under the MIT license.

using System;

namespace DontPanicLabs.CodeAnalysis
{
    public class Sample
    {
        public const int PublicConstant = 42;
        private const int PrivateConstant = 42;

        public static readonly int PublicStaticReadonlyField = 42;
        internal static readonly int s_internalStaticReadonlyField = 42;
        private static readonly int s_privateStaticReadonlyField = 42;

        internal static int s_internalStaticField = 42;
        private static int s_privateStaticField = 42;

        private readonly int _privateReadonlyField = 42;

        internal int _internalField = 42;
        private int _privateField = 42;

        public int PublicProperty => 42;
        public int PublicProperty2 { get; private set; } = 42;

        public int PublicProperty3
        {
            get;
            private set;
        }

        private int PrivateProperty { get; set; }

        public void Method()
        {
            if (true)
            {
                Console.WriteLine(42);
            }

            var action1 = () =>
            {
                Console.WriteLine(42);
            };

            var action2 = () => Console.WriteLine(42);

            static void StaticLocalFunction()
            {
                Console.WriteLine(42);
            }

            void LocalFunction()
            {
                Console.WriteLine(42);
            }

            var array = new[] { 1, 2, 3 }
                .Select(static i => i * 2)
                .ToArray();

            Func<int, int> lambda = i => i * 2;
            Func<int, int> staticLambda = static i => i * 2;

            var class1 = new Class();
            var class2 = new Class { Property = 42 };

            // Print things to remove "unused" warnings.
            Console.WriteLine(s_internalStaticReadonlyField);
            Console.WriteLine(s_privateStaticReadonlyField);
            Console.WriteLine(++s_internalStaticField);
            Console.WriteLine(++s_privateStaticField);
            Console.WriteLine(_privateReadonlyField);
            Console.WriteLine(++_internalField);
            Console.WriteLine(++_privateField);
            Console.WriteLine(array.Length);

            action1();
            action2();
            StaticLocalFunction();
            LocalFunction();
            Console.WriteLine(lambda(42));
            Console.WriteLine(staticLambda(42));
            Console.WriteLine(class1.Property);
            Console.WriteLine(class2.Property);
        }

        public void SystemUnderTest_WhenCondition_ExpectResult()
        {
        }
    }

    public class Class
    {
        public int Property { get; init; }

        public Class()
        {
            Property = 42;
        }
    }

    public class Record(int property);

    // Import statements can't be inside the namespace.
    // using System.Text;

    public class Errors
    {
        // No public fields.
        // public static int PublicStaticField = 42;
        // public readonly int PublicReadonlyField = 42;
        // public int PublicField = 42;

        public Errors()
        {
            // One-liner is not allowed
            // if (true) Console.WriteLine(42);
        }

        // Not allowed
        // public void ArrowMethod() => Console.WriteLine("Hello, world!");
    }
}
