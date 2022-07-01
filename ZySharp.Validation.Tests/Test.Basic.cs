﻿using System;
using System.Collections.Generic;

using Xunit;

namespace ZySharp.Validation.Tests
{
    public sealed partial class Test
    {
        #region NotNull

        public static IEnumerable<object[]> DataNotNullRef => new List<object[]>
        {
            new object[] { new RefTestCase<object>(new object(), false                               ) },
            new object[] { new RefTestCase<string>(string.Empty, false                               ) },
            new object[] { new RefTestCase<string>("test"      , false                               ) },
            new object[] { new RefTestCase<Obj   >(Obj.A       , false                               ) },
            new object[] { new RefTestCase<object>(null        , true , typeof(ArgumentNullException)) }
        };

        [Theory]
        [MemberData(nameof(DataNotNullRef))]
        public void Test_NotNull_Ref<T>(RefTestCase<T> test)
            where T : class
        {
            TestExtensions.TestValidation(test, v => v.NotNull());
        }

        public static IEnumerable<object[]> DataNotNullVal => new List<object[]>
        {
            new object[] { new ValTestCase<int     >(0            , false                               ) },
            new object[] { new ValTestCase<int     >(null         , true , typeof(ArgumentNullException)) },
            new object[] { new ValTestCase<Guid    >(Guid.Empty   , false                               ) },
            new object[] { new ValTestCase<Guid    >(null         , true , typeof(ArgumentNullException)) },
            new object[] { new ValTestCase<TimeSpan>(TimeSpan.Zero, false                               ) },
            new object[] { new ValTestCase<TimeSpan>(null         , true , typeof(ArgumentNullException)) }
        };

        [Theory]
        [MemberData(nameof(DataNotNullVal))]
        public void Test_NotNull_Val<T>(ValTestCase<T> test)
            where T : struct
        {
            TestExtensions.TestValidation(test, v => v.NotNull());
        }

        #endregion NotNull

        #region NotEmpty

        public static IEnumerable<object[]> DataNotEmptyVal => new List<object[]>
        {
            new object[] { new ValTestCase<int     >(1            , false) },
            new object[] { new ValTestCase<int     >(null         , false) },
            new object[] { new ValTestCase<int     >(0            , true ) },
            new object[] { new ValTestCase<Guid    >(GuidA        , false) },
            new object[] { new ValTestCase<Guid    >(null         , false) },
            new object[] { new ValTestCase<Guid    >(Guid.Empty   , true ) },
            new object[] { new ValTestCase<TimeSpan>(TimeSpanA    , false) },
            new object[] { new ValTestCase<TimeSpan>(null         , false) },
            new object[] { new ValTestCase<TimeSpan>(TimeSpan.Zero, true ) },
        };

        [Theory]
        [MemberData(nameof(DataNotEmptyVal))]
        public void Test_NotEmpty_Val<T>(ValTestCase<T> test)
            where T : struct
        {
            TestExtensions.TestValidation(test, v => v.NotEmpty());
        }

        public static IEnumerable<object[]> DataNotEmptyEnumerable => new List<object[]>
        {
            new object[] { new RefTestCase<IEnumerable<int>>(new List<int>{ 1 }, false) },
            new object[] { new RefTestCase<IEnumerable<int>>(null              , false) },
            new object[] { new RefTestCase<IEnumerable<int>>(new List<int>()   , true ) },
        };

        [Theory]
        [MemberData(nameof(DataNotEmptyEnumerable))]
        public void Test_NotEmpty_Enumerable<T>(RefTestCase<IEnumerable<T>> test)
        {
            TestExtensions.TestValidation(test.Value, v => v.NotEmpty(), test.ExpectThrow);
        }

        public static IEnumerable<object[]> DataNotEmptyString => new List<object[]>
        {
            new object[] { new RefTestCase<string>("test"      , false) },
            new object[] { new RefTestCase<string>(null        , false) },
            new object[] { new RefTestCase<string>(string.Empty, true ) },
            new object[] { new RefTestCase<string>(""          , true ) },
        };

        [Theory]
        [MemberData(nameof(DataNotEmptyString))]
        public void Test_NotEmpty_String(RefTestCase<string> test)
        {
            TestExtensions.TestValidation(test.Value, v => v.NotEmpty(), test.ExpectThrow);
        }

        #endregion NotEmpty

        #region NotNullOrEmpty

        public static IEnumerable<object[]> DataNotNullOrEmptyRef => new List<object[]>
        {
            new object[] { new RefTestCase<string   >("test"            , false                               ) },
            new object[] { new RefTestCase<string   >(string.Empty      , true                                ) },
            new object[] { new RefTestCase<string   >(null              , true , typeof(ArgumentNullException)) },
            new object[] { new RefTestCase<List<int>>(new List<int>{ 1 }, false                               ) },
            new object[] { new RefTestCase<List<int>>(new List<int>()   , true                                ) },
            new object[] { new RefTestCase<List<int>>(null              , true , typeof(ArgumentNullException)) }
        };

        [Theory]
        [MemberData(nameof(DataNotNullOrEmptyRef))]
        public void Test_NotNullOrEmpty_Ref<T>(RefTestCase<T> test)
            where T : class
        {
            TestExtensions.TestValidation(test, v => v.NotNullOrEmpty());
        }

        public static IEnumerable<object[]> DataNotNullOrEmptyVal => new List<object[]>
        {
            new object[] { new ValTestCase<int     >(1            , false                               ) },
            new object[] { new ValTestCase<int     >(0            , true                                ) },
            new object[] { new ValTestCase<int     >(null         , true , typeof(ArgumentNullException)) },
            new object[] { new ValTestCase<Guid    >(GuidA        , false                               ) },
            new object[] { new ValTestCase<Guid    >(Guid.Empty   , true                                ) },
            new object[] { new ValTestCase<Guid    >(null         , true , typeof(ArgumentNullException)) },
            new object[] { new ValTestCase<TimeSpan>(TimeSpanA    , false                               ) },
            new object[] { new ValTestCase<TimeSpan>(TimeSpan.Zero, true                                ) },
            new object[] { new ValTestCase<TimeSpan>(null         , true , typeof(ArgumentNullException)) }
        };

        [Theory]
        [MemberData(nameof(DataNotNullOrEmptyVal))]
        public void Test_NotNullOrEmpty_Val<T>(ValTestCase<T> test)
            where T : struct
        {
            TestExtensions.TestValidation(test, v => v.NotNullOrEmpty());
        }

        #endregion NotNullOrEmpty
    }
}