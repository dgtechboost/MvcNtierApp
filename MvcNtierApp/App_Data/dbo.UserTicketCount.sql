USE [MvcNtier]
GO
/****** Object:  StoredProcedure [dbo].[UserTicketCount]    Script Date: 27-Feb-17 13:18:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[UserTicketCount] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select u.Name,
	COUNT((case when t.StatusID = 1 then t.StatusID end)) as [Open], 
	COUNT((case when t.StatusID = 2 then t.StatusID end)) as [WIP],
	COUNT((case when t.StatusID = 5 then t.StatusID end)) as [Closed]
	from MvcNtier.dbo.Ticket t
	inner join [MvcNtier].[dbo].[Type] ty on t.TicketTypeID = ty.ID
	inner join MvcNtier.dbo.[Status] s on t.StatusID = s.ID
	inner join [MvcNtier].[dbo].[Users] u on t.AllocatedToID = u.ID
	group by u.Name
	order by NEWID()
END
