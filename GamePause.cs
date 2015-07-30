// GamePause.cs
// This file is an example of the extension of the GameEventsBroadcaster system.
// By copying and changing the names, it is possible to add more events to the system.

namespace Net.Xeophin.Utils
{
  using System;

  #region Pause Events

  /// <summary>
  /// Example implementation of additional events for the Game Events Broadcaster.
  /// </summary>
  public partial class GameEventsBroadcaster
  {

    /// <summary>
    /// Occurs when the game is paused.
    /// </summary>
    public event EventHandler<GameStateEventArgs> PauseGame {
      add {
        Add (GameState.EnterPause, value);
       
      }
      remove {
        Remove (GameState.EnterPause, value);
      }
    }


    /// <summary>
    /// Occurs when the game is unpaused.
    /// </summary>
    public event EventHandler<GameStateEventArgs> UnpauseGame {
      add {
        Add (GameState.ExitPause, value);
      }
      remove {
        Remove (GameState.ExitPause, value);
      }
    }

  }

  /// <summary>
  /// Additional game states
  /// </summary>
  static public partial class GameState
  {
    /// <summary>
    /// The enter pause state.
    /// </summary>
    /// <description>
    /// This functions as an enum – it is static and read-only, so whenever you
    /// access this state, you should get the same GUID. This GUID is then used
    /// to access the correct handlers in the handler dictionary.
    /// </description>
    public static readonly Guid EnterPause = Guid.NewGuid ();
    public static readonly Guid ExitPause = Guid.NewGuid ();
  }

  #endregion
}



