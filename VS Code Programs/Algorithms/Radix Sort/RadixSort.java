import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.RandomAccessFile;
import java.util.Random;
import java.util.Scanner;

public class RadixSort {

    private static RandomAccessFile file;
    private static RandomAccessFile zero;
    private static RandomAccessFile one;

    public static void main(String[] args) {
        try {
            file = new RandomAccessFile("file.dat", "rw");
            zero = new RandomAccessFile("zero.dat", "rw");
            one = new RandomAccessFile("one.dat", "rw");
            int x;
            int y;
            Scanner in = new Scanner(System.in);
            System.out.print("Enter Size: ");
            x = in.nextInt();
            System.out.print("Enter Upper Bound: ");
            y = in.nextInt();
            System.out.println();
            generateRandomFile(x,y);
            sort(x);
            printFiles(x);

        }catch (FileNotFoundException ex){
            System.out.println("File not found");
        }
    }

    private static void generateRandomFile(int size,int bound){
        try{
            Random random = new Random();
            System.out.println("Random Order: ");
            for (int i = 0; i < size; i++) {
                int x = random.nextInt(bound + 1);
                x = Math.abs(x);
                file.writeInt(x);
                System.out.println((i + 1) + ": " + x);
            }

            file.seek(0);
        }catch (IOException ex){
            System.out.println("File Error");
        }
    }

    public static void sort(int size){
        try {
            int mask = 0X00000001;
            for (int i = 0; i < 32; i++) {
                int z = 0,o = 0;
                file.seek(0);
                zero.seek(0);
                one.seek(0);
                for (int j = 0; j < size; j++) {
                    int n = file.readInt();
                    if ((n & (mask << i)) == 0){
                        zero.writeInt(n);
                        z++;
                    }else {
                        one.writeInt(n);
                        o++;
                    }

                }
                one.seek(0);
                for (int j = 0; j < o; j++) {
                    int n = one.readInt();
                    zero.writeInt(n);
                }

                RandomAccessFile temp = zero;
                zero = file;
                file = temp;
//                printFiles(size);
            }



        }catch (IOException ex){
            System.out.println("\nFile Error");
        }
    }

    public static void printFiles(int size){

        try{
            System.out.println("\n\nSorted Order:");
            file.seek(0);
            for (int i = 0; i < size; i++) {
                int n = file.readInt();
                System.out.println((i+1) + ": " + n);

            }
            file.close();
            zero.close();
            one.close();
        }catch (IOException ex){
            System.out.println("File Error");
        }
    }

}
