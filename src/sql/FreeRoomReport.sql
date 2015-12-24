select rm.* from Rooms rm
	where not exists(
		select * from Reservations rs
			where 
				rs.RoomId = rm.Id and
				(rs.ArrivalDate < '{0}' and rs.DepartureDate > '{1}' or
                 rs.ArrivalDate < '{0}' and rs.DepartureDate > '{1}' or 
				 rs.ArrivalDate >= '{0}' and rs.DepartureDate <= '{1}'));