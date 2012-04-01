# Windows Phone Notificator

Simple way to send Tile and Toast notifications for your application

# How to use

## Sending Tile notification

```csharp

const string httpNotification = @"yourURL";
	
var notification = new TileNotification
{
	Tile = new Tile
	{
	    Count = 2,
	    BackContent = "Back Content",
	    BackTitle = "Back Title"
	}
};
	
var tileNotification = new WindowsPhoneNotification(notification, httpNotification);
	
tileNotification.SendNotification();
```

## Sending Toast notification

```csharp

const string httpNotification = @"yourURL";
	
var notification = new ToastNotification
{
	Toast = new Toast
	{
	    Test1 = "Abc",
	    Test2 = "Def",
	    PathToOpen = "/AnotherPage.xaml?IsToast=true"
	}
};
	
var tileNotification = new WindowsPhoneNotification(notification, httpNotification);
	
tileNotification.SendNotification();
```