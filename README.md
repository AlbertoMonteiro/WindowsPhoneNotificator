# Windows Phone Notificator

Simple way to send Tile and Toast notifications for your application

# Usager

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