namespace Net.Xeophin.Utils
{
  using UnityEngine;
  using Net.Xeophin.Utils;
  using NUnit.Framework;

  [TestFixture]
  public class GameEventsBroadcasterTest
  {
    [Test]
    public void AddHandler ()
    {
      GameEventsBroadcaster.Instance.PauseGame += Pass;
      GameEventsBroadcaster.Instance.RaiseGameStateChanged (this, new GameStateEventArgs (GameState.EnterPause));

    }

    [Test]
    public void TryToRemovePreviouslyRegisteredHandler ()
    {
      GameEventsBroadcaster.Instance.PauseGame += GameEventsBroadcaster_Instance_PauseGame;
      GameEventsBroadcaster.Instance.PauseGame -= GameEventsBroadcaster_Instance_PauseGame;
    }

    [Test]
    public void TryToRemoveUnregisteredHandler ()
    {
      GameEventsBroadcaster.Instance.PauseGame += GameEventsBroadcaster_Instance_PauseGame;
      GameEventsBroadcaster.Instance.PauseGame -= GameEventsBroadcaster_Instance_PauseGame1;
    }

    [Test]
    public void TryToRemoveFromPreviouslyUnregisteredEvent ()
    {
      GameEventsBroadcaster.Instance.UnpauseGame -= Counter;
    }

    [Test]
    public void CheckThatHandlerIsntCalledAfterBeingRemoved ()
    {
      GameEventsBroadcaster.Instance.UnpauseGame += Fail;
      GameEventsBroadcaster.Instance.UnpauseGame -= Fail;

      GameEventsBroadcaster.Instance.RaiseGameStateChanged (this, new GameStateEventArgs (GameState.ExitPause));
    }


    void Pass (object sender, GameStateEventArgs e)
    {
      Assert.Pass ("Handler Pass 1 has been executed.");

    }

    void Fail (object sender, GameStateEventArgs e)
    {
      Assert.Fail ("Handler has been called although it shouldnt."); 
    }

    void Counter (object sender, GameStateEventArgs e)
    {

    }

 

    void GameEventsBroadcaster_Instance_PauseGame1 (object sender, GameStateEventArgs e)
    {
      Debug.Log ("[Test] Oh hai. Calling from the second handler.");
    }

    void GameEventsBroadcaster_Instance_PauseGame (object sender, GameStateEventArgs e)
    {
      Debug.Log ("[Test] This is shown when the PauseEnter event has been fired.");
    }
  }
}

