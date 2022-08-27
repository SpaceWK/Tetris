using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TetrisFinal1
{
    class BlockPositionSpawner
    {
        // clasa pentru a verifica ce bloc a fost jucat 
        public BlockPositionSpawner() {

            if (loadedPositions != null && loadedPositions.Count != 0)
            {
                currentBucket = new Piesa[loadedPositions.Count];
                nextBucket = new Piesa[loadedPositions.Count];
            }
            else
            {
                currentBucket = new Piesa[7];
                nextBucket = new Piesa[7];
            }

            setPossiblePositions(currentBucket);
            setPossiblePositions(nextBucket);
        }


        private Piesa[] currentBucket;

        private Piesa[] nextBucket;

        private Random rand = new Random();

        private int nextBlock = 0;

        // pozitia de start ce va fi incarcata
        private List<String[]> loadedPositions = null;

        // generator rendom de culori
        private Random randGen = new Random();

        // verific urm piesa ce se va juca
        public Piesa Next()
        {
            Piesa blockToReturn = currentBucket[nextBlock];
            currentBucket[nextBlock] = nextBucket[nextBlock];
            nextBlock++;

            if (nextBlock >= currentBucket.Length)
            {
                nextBlock = 0;
                setPossiblePositions(nextBucket);
            }

            return blockToReturn;
        }


        private void setPossiblePositions(Piesa[] bucket)
        {
            if (loadedPositions == null || loadedPositions.Count == 0)
            {
                setKnownPossiblePositions(bucket);
                setKnownPossiblePositions(bucket);
            }
            else
            {
                int count = 0;

                foreach (String[] block in loadedPositions)
                {
                    bucket[count] = new Piesa();
                    bucket[count].position = new Boolean[block.Length, block.Length];
                
                    for (var row = 0; row < block.Length; row++)
                    {
                        char[] rowArr = block[row].ToCharArray();
                        for (var col = 0; col < block[row].Length; col++)
                        {
                            bucket[count].position[row, col] = rowArr[col] == '#';
                        }
                    }
                    // dau culoarea random
                    KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
                    KnownColor randomColorName = names[randGen.Next(names.Length)];
                    bucket[count].color = Color.FromKnownColor(randomColorName);

                    count++;
                }
            }

            shuffle( bucket);
        }


        private void setKnownPossiblePositions(Piesa[] bucket)
        {

            bucket[0] = new Linie();

            bucket[1] = new Lstanga();

            bucket[2] = new Ldreapta();

            bucket[3] = new Cub();

            bucket[4] = new zigzagDreapta();

            bucket[5] = new zigzagDreapta();

            bucket[6] = new Triunghi();
        }

            // amestec piesele folosind Fisher Yates
            private void shuffle(Piesa[] bucket)
        {
            Piesa temp;
            for (int i = bucket.Length - 1; i > 0; i--)
            {
                int n = rand.Next(i + 1);
                temp = bucket[i];
                bucket[i] = bucket[n];
                bucket[n] = temp;
            }
        }
    }
}