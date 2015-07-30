namespace Net.Xeophin.Utils
{
  using System;
  using System.Collections.Generic;


  /// <summary>
  /// Class serves as a template for a notification hub that can be used within the
  /// game to trigger specific events.
  /// </summary>
  /// <remarks>
  /// This is a partial class. Additional events can be added by adding more files that add
  /// to this partial class. As an example, the GamePause.cs file has been added, see
  /// the commentaries there for a more thorough discussion.
  /// </remarks>
  public partial class GameEventsBroadcaster
  {
    #region Singleton

    /// <summary>
    /// Reference to the class instance (singleton).
    /// </summary>
    private static readonly GameEventsBroadcaster instance = new GameEventsBroadcaster ();

    /// <summary>
    /// Initializes a new instance of the <see cref="Net.Xeophin.Utils.GameEventsBroadcaster"/> class.
    /// </summary>
    protected GameEventsBroadcaster ()
    {
    }

    /// <summary>
    /// Gets the instance of the GameEventsBroadcaster.
    /// </summary>
    /// <value>The instance.</value>
    public static GameEventsBroadcaster Instance { get { return instance; } }


    #endregion

    /// <summary>
    /// The game state events dictionary 
    /// - this collects all event handlers.
    /// </summary>
    /// <remarks>
    /// Handlers are accessed by GUIDs. As a programmer, you don't need to know their values, as they are saved
    /// in the <see cref="Net.Xeophin.Utils.GameState"/> class.
    /// </remarks>
    private Dictionary<Guid,EventHandler<GameStateEventArgs>> gameStateEvents = new Dictionary<Guid, EventHandler<GameStateEventArgs>> ();

    #region Game State Changes

    /// <summary>
    /// Occurs when a general game state change occurs. Catch-all event, use when you
    /// look for several events at once or are not really sure what you're
    /// looking for.
    /// </summary>
    public event EventHandler<GameStateEventArgs> GameStateChanged;


    protected virtual void OnGameStateChanged (object sender, GameStateEventArgs e)
    {
      var handler = GameStateChanged;
      if (handler != null)
        handler (this, e);
    }


    /// <summary>
    /// Raises the game state changed event. This is the main entry point for all
    /// game state event changes.
    /// </summary>
    /// <param name="sender">Sender object.</param>
    /// <param name="e">The event arguments.</param>
    /// <remarks>
    /// This handles all game state changes, so you can just use one function to
    /// call all the events.
    /// 
    /// This method will then call more specific event invocators, so that objects
    /// dependent on those specific events can listen to those, and don't have
    /// to check whether they have to do something themselves.
    /// </remarks>
    public void RaiseGameStateChanged (object sender, GameStateEventArgs e)
    {
      // General Game state event.
      OnGameStateChanged (sender, e);

      // Call more specific events
      var handler = gameStateEvents [e.NewState];
      if (handler != null)
        handler (sender, e);

    }

    #endregion

    #region Helper methods

    /// <summary>
    /// Add the specified handler to the state list.
    /// </summary>
    /// <param name="state">The state when the handler should be called.</param>
    /// <param name="handler">The handler to call.</param>
    /// <remarks>
    /// This is a helper methods that is here to set up additional events.
    /// </remarks>
    void Add (Guid state, EventHandler<GameStateEventArgs> handler)
    {
      lock (gameStateEvents) {
        if (!gameStateEvents.ContainsKey (state)) {
          gameStateEvents.Add (state, handler);
        } else {
          gameStateEvents [state] += handler;
        }
      }
    }

    /// <summary>
    /// Remove the specified handler from an event.
    /// </summary>
    /// <param name="state">State.</param>
    /// <param name="handler">Handler.</param>
    void Remove (Guid state, EventHandler<GameStateEventArgs> handler)
    {
      lock (gameStateEvents) {
        if (gameStateEvents.ContainsKey (state)) {
          gameStateEvents [state] -= handler;
        }
      }
    }

    #endregion
  }



 

}