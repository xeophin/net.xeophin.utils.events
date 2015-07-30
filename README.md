# Event Broadcasting System for Unity3D

Use by registering your handlers with `GameEventsBroadcaster.Instance.YourEvent` and triggering 
them by calling `GameEventsBroadcaster.Instance.RaiseGameStateChanged(this, new GameStateEventArgs(GameState.YourEvent))`.

Extensible through the use of partial classes, refer to the included `GamePause.cs` file to see how it works.

## Test files

The test classes uses the *Unity Test Tools*, which can be obtained for free on the Unity Asset Store.
