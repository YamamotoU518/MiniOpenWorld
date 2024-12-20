public interface IPlayerInput
{
    /// <summary> Dキーが押されたとき </summary>
    public void InputRight();
    /// <summary> Aキーが押されたとき </summary>
    public void InputLeft();
    /// <summary> Wキーが押されたとき </summary>
    public void InputForward();
    /// <summary> Sキーが押されたとき </summary>
    public void InputBack();
    /// <summary> キーが離されたとき </summary>
    public void Release();
    /// <summary> 左クリックが押されたとき </summary>
    public void Attack();
}
