select 
	min(ht.Title) as HotelTitle,
	Count(*) as Count
from Reservations rs
	join Rooms rm on rs.RoomId = rm.Id
	join Hotels ht on ht.Id = rm.HotelId
where 
	rs.ArrivalDate < 'from' and rs.DepartureDate > 'from' or
	rs.ArrivalDate < 'to' and rs.DepartureDate > 'to' or
	rs.ArrivalDate >= 'from' and rs.DepartureDate <= 'to'
group by ht.Id;