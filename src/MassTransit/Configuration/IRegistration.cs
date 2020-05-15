namespace MassTransit
{
    using System;
    using ConsumeConfigurators;
    using Definition;
    using Registration;
    using Saga;


    /// <summary>
    /// Registration contains the consumers and sagas that have been registered, allowing them to be configured on one or more
    /// receive endpoints.
    /// </summary>
    public interface IRegistration :
        IConfigurationServiceProvider
    {
        /// <summary>
        /// Configure a consumer on the receive endpoint
        /// </summary>
        /// <param name="consumerType">The consumer type</param>
        /// <param name="configurator"></param>
        void ConfigureConsumer(Type consumerType, IReceiveEndpointConfigurator configurator);

        /// <summary>
        /// Configure a consumer on the receive endpoint, with an optional configuration action
        /// </summary>
        /// <param name="configurator"></param>
        /// <param name="configure"></param>
        /// <typeparam name="T">The consumer type</typeparam>
        void ConfigureConsumer<T>(IReceiveEndpointConfigurator configurator, Action<IConsumerConfigurator<T>> configure = null)
            where T : class, IConsumer;

        /// <summary>
        /// Configure all registered consumers on the receive endpoint
        /// </summary>
        /// <param name="configurator"></param>
        void ConfigureConsumers(IReceiveEndpointConfigurator configurator);

        /// <summary>
        /// Configure a saga on the receive endpoint
        /// </summary>
        /// <param name="sagaType">The saga type</param>
        /// <param name="configurator"></param>
        void ConfigureSaga(Type sagaType, IReceiveEndpointConfigurator configurator);

        /// <summary>
        /// Configure a saga on the receive endpoint, with an optional configuration action
        /// </summary>
        /// <param name="configurator"></param>
        /// <param name="configure"></param>
        /// <typeparam name="T">The saga type</typeparam>
        void ConfigureSaga<T>(IReceiveEndpointConfigurator configurator, Action<ISagaConfigurator<T>> configure = null)
            where T : class, ISaga;

        /// <summary>
        /// Configure all registered sagas on the receive endpoint
        /// </summary>
        /// <param name="configurator"></param>
        void ConfigureSagas(IReceiveEndpointConfigurator configurator);

        /// <summary>
        /// Configure the specified execute activity type
        /// </summary>
        /// <param name="activityType"></param>
        /// <param name="configurator"></param>
        void ConfigureExecuteActivity(Type activityType, IReceiveEndpointConfigurator configurator);

        /// <summary>
        /// Configure the specified activity type
        /// </summary>
        /// <param name="activityType"></param>
        /// <param name="executeEndpointConfigurator">The configurator for the execute activity endpoint</param>
        /// <param name="compensateEndpointConfigurator">The configurator for the compensate activity endpoint</param>
        void ConfigureActivity(Type activityType, IReceiveEndpointConfigurator executeEndpointConfigurator,
            IReceiveEndpointConfigurator compensateEndpointConfigurator);

        /// <summary>
        /// Configure the specified activity type
        /// </summary>
        /// <param name="activityType"></param>
        /// <param name="executeEndpointConfigurator">The configurator for the execute activity endpoint</param>
        /// <param name="compensateAddress"></param>
        void ConfigureActivityExecute(Type activityType, IReceiveEndpointConfigurator executeEndpointConfigurator, Uri compensateAddress);

        /// <summary>
        /// Configure the specified activity type
        /// </summary>
        /// <param name="activityType"></param>
        /// <param name="compensateEndpointConfigurator">The configurator for the compensate activity endpoint</param>
        void ConfigureActivityCompensate(Type activityType, IReceiveEndpointConfigurator compensateEndpointConfigurator);

        /// <summary>
        /// Configure the endpoints for all defined consumer, saga, and activity types using an optional
        /// endpoint name formatter. If no endpoint name formatter is specified and an <see cref="IEndpointNameFormatter"/>
        /// is registered in the container, it is resolved from the container. Otherwise, the <see cref="DefaultEndpointNameFormatter"/>
        /// is used.
        /// </summary>
        /// <param name="configurator">The <see cref="IBusFactoryConfigurator"/> for the bus being configured</param>
        /// <param name="endpointNameFormatter">Optional, the endpoint name formatter</param>
        /// <typeparam name="T">The bus factory type (depends upon the transport)</typeparam>
        void ConfigureEndpoints<T>(IReceiveConfigurator<T> configurator, IEndpointNameFormatter endpointNameFormatter)
            where T : IReceiveEndpointConfigurator;
    }
}
