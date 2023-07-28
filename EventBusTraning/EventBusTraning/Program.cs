using EventBusTraning.EventBus;
using EventBusTraning.Method;

class Program
{
    static void Main(string[] args)
    {
        EventBus eventBus = new EventBus();

        // Đăng ký xử lý sự kiện UserRegisteredEvent
        eventBus.Subscribe<UserRegisteredEvent>(OnUserRegistered);

        // Phát sinh sự kiện UserRegisteredEvent
        UserRegisteredEvent userRegisteredEvent = new UserRegisteredEvent { UserName = "JohnDoe" };
        eventBus.Publish(userRegisteredEvent);
    }

    static void OnUserRegistered(UserRegisteredEvent userRegisteredEvent)
    {
        Console.WriteLine($"User {userRegisteredEvent.UserName} has been registered.");
    }
}
//Khi chạy chương trình, bạn sẽ nhận được thông báo "User JohnDoe has been registered." do sự kiện UserRegisteredEvent đã được phát sinh và xử lý bởi phương thức OnUserRegistered.





