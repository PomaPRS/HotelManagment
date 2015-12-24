select 
	min(hs.Title) as HotelTitle,
	min(rm.Number) as RoomNumber,
	Count(*) as Count
from Visitors vs
	join Reservations rs on vs.Id = rs.VisitorId
	join Rooms rm on rm.Id = rs.RoomId
	join Hotels hs on hs.Id = rm.HotelId
where vs.FirstName + vs.MiddleName + vs.SecondName like '%1%' 
group by rm.Id;