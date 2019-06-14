
namespace BinarySoftCo.UIControls
{
    public delegate void CloseDropDownControlHandler();

    /// <summary>
    /// Every control, that you need to use as a child control of Extensive combo, must implement
    /// this interface.
    /// </summary>
    public interface IDropDownControl
    {
        ///if you want to modify look and feel of your control inside the combobox then
        ///use this method to set look and feel properties
        void SetUserInterface();
        
        /// This delegate would empower the child control to close the combobox drop down
        /// e.g you want to close drop down of combo when you double click child control
        CloseDropDownControlHandler CloseDropDownControlDelegate { get; set; }

        /// Text returned by this property would be used by combobox to display text while
        /// drop down is closed
        string DisplayText
        {
            get;
        }

        object SelectedValue
        {
            get;
            set;
        }
    }
}
