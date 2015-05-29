# ObjectivesManager

With this package, you can easily add objectives to your Unity3D games.
You can see it working on the demo scene.
Unity3D 5 or newer is required.

### Geting started

- [Download](https://github.com/aftersixgames/ObjectivesManager/releases/tag/0.0.1) the package
- Import on yout Unity3D project.
- Add an EventSystem to yout scene if it doesn't already have one
- Drag the `ObjectivesController` prefab to your scene.
- Add your objectives list
- Create a new prefab with your customized objectives or apply the changes to the original.
- Add the `ObjectivesController`instance to your script.
- Add progress to your objectives.

### Features

#### Add progress

Add progress to a objective specifying the objective key and the amount of progress.

```c#
objectivesController.AddProgress("objective_key", 1);
```

#### Show current objectives

Open a window showing the current objectives. You can pass a lambda witch is invoked the the window is closed.

```c#
objectivesController.ShowCurrentObjectives(() => {  print("Window closed"); });
```

#### Hide current objectives

Closes the current objectives window. If a lambda was passed on `ShowCurrentObjectives` method, it will be executed here.

```c#
objectivesController.HideCurrentObjectives();
```

#### Show completed objectives

Open a window showing all the completed objectives. You can pass a lambda witch is invoked the the window is closed.

```c#
objectivesController.ShowCompletedObjectives(() => {  print("Window closed"); });
```

#### Hide completed objectives

Closes the completed objectives window. If a lambda was passed on `ShowCompletedtObjectives` method, it will be executed here.

```c#
objectivesController.HideCompletedObjectives();
```

#### Get current objectives controller

You can get the `ObjectivesController` instance on the scene. Optionally you can specify the game object name. If none is given "ObjectivesController" is assumed.

```c#
objectivesController.GetCurrent("MyObjectivesController");
```

### Contributing

1. Fork it ( https://github.com/aftersixgames/ObjectivesManager/fork )
2. Create your feature branch (`git checkout -b my-new-feature`)
3. Commit your changes (`git commit -am 'Add some feature'`)
4. Push to the branch (`git push origin my-new-feature`)
5. Create a new Pull Request
