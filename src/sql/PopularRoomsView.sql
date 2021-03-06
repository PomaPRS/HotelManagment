create view PopularRooms as
	select 
		rooms.Id as Id,
		min(hotels.Title) as HotelTitle, 
		min(rooms.Number) as RoomNumber, 
		Count(*) as VisitorCount 
	from [HotelDatabase].[dbo].[Rooms] as rooms
		join [HotelDatabase].[dbo].[Hotels] as hotels 
			on rooms.HotelId = hotels.Id
		join [HotelDatabase].[dbo].[Reservations] as reservations
			on reservations.RoomId = rooms.Id
	group by rooms.Id
	having count(*) > 1;