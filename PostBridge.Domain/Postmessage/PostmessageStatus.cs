namespace PostBridge.Domain.Postmessage
{
    public enum PostmessageStatus
    {
        /// <summary>
        /// Создан, не задействован в процессе отправления
        /// </summary>
        Creation = 0,
        /// <summary>
        /// Был отправлен в шину, но нет подтверждения доставки
        /// </summary>
        TrySend = 1,
        /// <summary>
        /// Получено подтверждение о доставке в шину
        /// </summary>
        Sent = 2
    }
}
