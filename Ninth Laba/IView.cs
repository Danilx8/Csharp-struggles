namespace Ninth_Laba
{
    interface IView
    {
        string GetMainPath();
        string GetSecondaryPath();
        void ShowResult(Synchronizations Result);
        void Connected(bool Success);
        event EventHandler<EventArgs> Synchronize;
    }
}
