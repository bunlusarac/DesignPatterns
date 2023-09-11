using DesignPatterns.Behavioral.NullObject;

namespace DesignPatterns.Test.Behavioral.NullObject;

public class NullObjectTest
{
    private string[] _expectedCustomerNames = new[] { "Barış", "Göktuğ", "Selen", "Adem" };
    
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void CustomerRepository_RetrievesExistingCustomersInNonNullObject(long customerId)
    {
        var repo = new CustomerRepository();
        var customer = repo.GetById(customerId);
        Assert.Equal(_expectedCustomerNames[customerId], customer.Name);
    }
    
    [Fact]
    public void CustomerRepository_ThrowsExceptionWhenNotFoundWithoutNullObject()
    {
        var repo = new CustomerRepository();
        Assert.Throws<InvalidOperationException>(() => repo.GetById(5));
    }
    
    [Fact]
    public void CustomerRepository_DoesNotThrowExceptionWhenNotFoundWithNullObject()
    {
        var repo = new CustomerRepository();
        var nullCustomer = repo.GetByIdWithNullObjectSupport(5);
        
        Assert.NotNull(nullCustomer);
        Assert.Equal(-1, nullCustomer.Id);
        Assert.Equal(string.Empty, nullCustomer.Name);
    }
    
    [Fact]
    public void CustomerHelper_ThrowsExceptionWhenProvidedNullReference()
    {
        ICustomer? nullReference = null;
        
        Assert.Throws<InvalidOperationException>(() => CustomerHelper.PrintCustomerDetails(nullReference));
        Assert.Throws<NullReferenceException>(() => CustomerHelper.PrintCustomerDetailsWithoutNullChecks(nullReference));
    }
    
    [Fact]
    public void CustomerHelper_DoesNotThrowExceptionWhenProvidedNullObject()
    {
        ICustomer nullCustomer = new NullCustomer();

        var exc1 = Record.Exception(() => CustomerHelper.PrintCustomerDetails(nullCustomer));
        var exc2 = Record.Exception(() => CustomerHelper.PrintCustomerDetailsWithoutNullChecks(nullCustomer));
        
        Assert.Null(exc1);
        Assert.Null(exc2);
    }
}