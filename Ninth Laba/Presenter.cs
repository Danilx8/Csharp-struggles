namespace Ninth_Laba
{
    class Presenter
    {
        private IView view;
        private Model model;
        public Presenter(IView NewView)
        {
            view = NewView;
            view.Synchronize += new EventHandler<EventArgs>(PassStates);
        }

        public void PassStates(object sender, EventArgs e)
        {
            Synchronizations Result;
            if (model == null)
            {
                model = new Model(view.GetMainPath(), view.GetSecondaryPath());
                view.Connected(model.Synchronize());
            }
            else
            {
                Result = model.CheckStates();
                view.ShowResult(Result);
            }
        }
    }
}
