namespace Net.Xeophin.Utils
{
  using System;

  /// <summary>
  /// Game state event arguments.
  /// </summary>
  public class GameStateEventArgs : EventArgs
  {
    public readonly Guid NewState;
    public readonly Guid OldState;
    public readonly object OriginalSender;

    public GameStateEventArgs (Guid newState, object originalSender)
    {
      this.NewState = newState;
      this.OriginalSender = originalSender;
    }

    public GameStateEventArgs (Guid newState)
    {
      this.NewState = newState;
    }

    public GameStateEventArgs (Guid newState, Guid oldState)
    {
      this.NewState = newState;
      this.OldState = oldState;
    }
  }
}
