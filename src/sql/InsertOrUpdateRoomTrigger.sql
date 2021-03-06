use [HotelDatabase]
go
create trigger InsertOrUpdateRoomTrigger
	on [HotelDatabase].[dbo].[Rooms]
	after insert, update
	as
	begin
		update Rooms
			set CostPerDay = PlaceCount * 400
			where 
				CostPerDay < PlaceCount * 400;
	end;