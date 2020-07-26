namespace PostBridge.Domain.Postmessage
{
    public enum PostmessageStatus
    {
        /// <summary>
        /// Создан, не задействован в процессе отправления
        /// </summary>
        Creation = 0,
        /// <summary>
        /// Отправка в шину завершилась нейдачей
        /// </summary>
        TrySend = 1,
        /// <summary>
        /// Отправка в шину завершилась удачей
        /// </summary>
        Sent = 2,
        /// <summary>
        /// Получено из шины
        /// </summary>
        Receved = 3
    }
}
