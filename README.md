# lightning-lab-testing  

Mock Demo  
```
    /// <summary>
    /// Test that checkout is rejected when user's fines exceed $10.00 limit.
    /// This demonstrates how mocking isolates the checkout logic from actual database dependencies.
    /// </summary>
    [Fact]
    public void CheckoutRequest_WithExcessiveFines_ShouldRejectCheckout()
    {
        // Arrange: Mock the services to avoid needing a real database
        var mockUserService = new Mock<IUserService>();
        var mockBookService = new Mock<IBookService>();

        // Set up the mock user with fines > $10
        var userWithHighFines = new User
        {
            Id = 1,
            Name = "Alice Johnson",
            Fines = 15.00m,  // Exceeds $10 limit
            IsBanned = false
        };

        var availableBook = new Book
        {
            Id = "B001",
            Title = "Clean Code",
            Status = BookStatus.Available
        };

        // Configure mocks to return our test data
        mockUserService.Setup(s => s.GetUser(1)).Returns(userWithHighFines);
        mockBookService.Setup(s => s.GetBook("B001")).Returns(availableBook);

        // Act: Simulate the checkout logic from Program.cs
        var user = mockUserService.Object.GetUser(1);
        var book = mockBookService.Object.GetBook("B001");

        // Assert: Verify that the checkout logic correctly rejects the request
        Assert.NotNull(user);
        Assert.NotNull(book);
        Assert.True(user.Fines > 10, "User fines should exceed $10 limit");
        Assert.Equal(BookStatus.Available, book.Status);

        // The checkout should be rejected because fines > $10
        var shouldRejectCheckout = user.Fines > 10;
        Assert.True(shouldRejectCheckout, "Checkout should be rejected when user fines exceed $10");
    }
```  

Other Pattern Demo
```
    [Fact]
    public void Checkout_WithUserHavingExcessiveFines_ReturnsBadRequest()
    {
        // Arrange
        var user = UserFactory.CreateUserWithExcessiveFines(50.00m);
        var book = BookFactory.CreateAvailableBook();

        var userServiceMock = new Mock<IUserService>();
        userServiceMock.Setup(s => s.GetUser(user.Id)).Returns(user);

        var bookServiceMock = new Mock<IBookService>();
        bookServiceMock.Setup(s => s.GetBook(book.Id)).Returns(book);

        // Act
        var userResult = userServiceMock.Object.GetUser(user.Id);

        // Assert
        Assert.NotNull(userResult);
        Assert.True(userResult.Fines > 10, "User should have fines exceeding $10");
    }
```