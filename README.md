# FootballWorldCupScore

## Dependencies

	- Log4Net
	
## HowTo

This a simple library where you can instantiate a football score board.

Simple add a new Operations interface, withe the implementation InMemoryOperations.

InMemoryOperations stores in memory all the match result buy you can implement a new IOperation where you can store in more persistence system like DB or the hard disk.

```C#
	IOperations operations = new InMemoryOperations();

	operations.StartGame("France", "Spain");
```