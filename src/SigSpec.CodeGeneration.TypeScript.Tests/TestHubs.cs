using Microsoft.AspNetCore.SignalR;

namespace SigSpec.CodeGeneration.TypeScript.Tests;

public class HubWithString : Hub<IClient>
{
	public Task Method(string message)
	{
		return Task.CompletedTask;
	}
}

public class HubWithStringOptional : Hub<IClient>
{
	public Task Method(string? message)
	{
		return Task.CompletedTask;
	}
}

public class HubWithInt : Hub<IClient>
{
	public Task Method(int message)
	{
		return Task.CompletedTask;
	}
}

public class HubWithIntOptional : Hub<IClient>
{
	public Task Method(int? message)
	{
		return Task.CompletedTask;
	}
}

public class HubWithGuid : Hub<IClient>
{
	public Task Method(Guid message)
	{
		return Task.CompletedTask;
	}
}

public class HubWithGuidOptional : Hub<IClient>
{
	public Task Method(Guid? message)
	{
		return Task.CompletedTask;
	}
}

public class HubWithStruct : Hub<IClient>
{
	public Task Method(TestStruct message)
	{
		return Task.CompletedTask;
	}
}

public class HubWithNullableStruct : Hub<IClient>
{
	public Task Method(Nullable<TestStruct> message)
	{
		return Task.CompletedTask;
	}
}

public class HubWithStructOptional : Hub<IClient>
{
	public Task Method(TestStruct? message)
	{
		return Task.CompletedTask;
	}
}

public class HubWithObject : Hub<IClient>
{
	public Task Method(TestClass message)
	{
		return Task.CompletedTask;
	}
}

public class HubWithObjectOptional : Hub<IClient>
{
	public Task Method(TestClass? message)
	{
		return Task.CompletedTask;
	}
}

public class HubWithBool : Hub<IClient>
{
	public Task Method(bool message)
	{
		return Task.CompletedTask;
	}
}

public class HubWithBoolOptional : Hub<IClient>
{
	public Task Method(bool? message)
	{
		return Task.CompletedTask;
	}
}

public class HubWithReturnInt : Hub<IClient>
{
	public Task<int> Method()
	{
		return Task.FromResult(0);
	}
}

public class HubWithReturnNullableInt : Hub<IClient>
{
	public Task<int?> Method()
	{
		return Task.FromResult((int?)0);
	}
}

public class HubWithReturnTestClass : Hub<IClient>
{
	public Task<TestClass> Method()
	{
		return Task.FromResult(new TestClass());
	}
}

public class HubWithReturnOptionalTestClass : Hub<IClient>
{
	public Task<TestClass?> Method()
	{
		return Task.FromResult((TestClass?)null);
	}
}


public interface IClient
{
	void ClientAction();
}

public struct TestStruct
{
	public string a;
	public bool b;
}

public class TestClass
{
	public string? a;
	public bool b;
}