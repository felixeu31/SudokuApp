using NUnit.Framework;
using SudokuApp.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuApp.UnitTests.Base
{
    public abstract class TestBase
    {
        //public static T AssertPublishedDomainEvent<T>(Entity aggregate)
        //    where T : IDomainEvent
        //{
        //    var domainEvent = DomainEventsTestHelper.GetAllDomainEvents(aggregate).OfType<T>().SingleOrDefault();

        //    if (domainEvent == null)
        //    {
        //        throw new Exception($"{typeof(T).Name} event not published");
        //    }

        //    return domainEvent;
        //}

        //public static void AssertDomainEventNotPublished<T>(Entity aggregate)
        //    where T : IDomainEvent
        //{
        //    var domainEvent = DomainEventsTestHelper.GetAllDomainEvents(aggregate).OfType<T>().SingleOrDefault();
        //    Assert.Null(domainEvent);
        //}

        //public static List<T> AssertPublishedDomainEvents<T>(Entity aggregate)
        //    where T : IDomainEvent
        //{
        //    var domainEvents = DomainEventsTestHelper.GetAllDomainEvents(aggregate).OfType<T>().ToList();

        //    if (!domainEvents.Any())
        //    {
        //        throw new Exception($"{typeof(T).Name} event not published");
        //    }

        //    return domainEvents;
        //}

        public static void AssertBrokenRule<TRule>(TestDelegate testDelegate)
            where TRule : class, IBusinessRule
        {
            var message = $"Expected {typeof(TRule).Name} broken rule";
            var businessRuleValidationException = Assert.Catch<BusinessRuleValidationException>(testDelegate, message);
            if (businessRuleValidationException != null)
            {
                Assert.That(businessRuleValidationException.BrokenRule, Is.TypeOf<TRule>(), message);
            }
        }

        public static void AssertBrokenRule<TRule>(AsyncTestDelegate testDelegate)
            where TRule : class, IBusinessRule
        {
            var message = $"Expected {typeof(TRule).Name} broken rule";
            var businessRuleValidationException = Assert.CatchAsync<BusinessRuleValidationException>(testDelegate, message);
            if (businessRuleValidationException != null)
            {
                Assert.That(businessRuleValidationException.BrokenRule, Is.TypeOf<TRule>(), message);
            }
        }

        //[TearDown]
        //public void AfterEachTest()
        //{
        //    SystemClock.Reset();
        //}
    }
}