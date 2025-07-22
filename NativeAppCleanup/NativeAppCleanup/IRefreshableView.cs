namespace NAppClean

{
    /// <summary>
    /// Represents a view that can be refreshed to update its display or data.
    /// </summary>
    /// <remarks>Implement this interface in views that require a mechanism to refresh their content, such as
    /// updating displayed data or re-rendering UI elements.</remarks>
    public interface IRefreshableView
    {
        void RefreshView();
    }
}