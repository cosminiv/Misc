package JavaTest;


public final class App {
    private App() {
    }

    public static void main(String[] args) {
        new DCP_012().test();
        //System.out.println(String.format("result = %d", n));
        
    }

    static <T> void Print(T a){
        System.out.println(a);
    }
}
