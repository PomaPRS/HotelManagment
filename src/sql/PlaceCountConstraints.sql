alter table [HotelDatabase].[dbo].[Rooms]
	add constraint PlaceCount_Default default 1 for [PlaceCount];

alter table [HotelDatabase].[dbo].[Rooms]
	add constraint PlaceCount_Check check ([PlaceCount] > 0);