namespace TaskFoobar;

class Foobar{
    public static void Task(int input){
        for(int i=1;i<=input;i++){
            if(i%3==0 && i%5==0){
                Console.WriteLine("Foobar");
            }
            else if(i%3==0){
                Console.WriteLine("Foo");
            }
            else if(i%5==0){
                Console.WriteLine("Bar");
            }
            else{
                Console.WriteLine(i);
            }
        }
    }
}