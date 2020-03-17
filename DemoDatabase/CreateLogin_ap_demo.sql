USE [master]
GO

/* For security reasons the login is created disabled and with a random password. */
/****** Object:  Login [ap_demo]    Script Date: 17.03.20 13:10:30 ******/
CREATE LOGIN [ap_demo] WITH PASSWORD=N'oEpsVoe7ymfUQ2x7iYkgsPJJocX4FiX9rBJZzR1MA1Y=', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=ON, CHECK_POLICY=ON
GO

ALTER LOGIN [ap_demo] DISABLE
GO

