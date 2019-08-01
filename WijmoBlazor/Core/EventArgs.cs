namespace WJ
{
    public class EventArgs
    {
    }
    public class CancelEventArgs : EventArgs
    {
        public bool Cancel { get; set; }
    }
}
