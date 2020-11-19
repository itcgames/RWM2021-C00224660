using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestSuite
    {
        private Grid grid;
        private int m_tileWidth;
        private int m_tileHeight;
        private float m_cellSize;
        private Vector3 mapOriginPosition;

        [SetUp]
        public void Setup()
        {
            m_tileWidth = 16;
            m_tileHeight = 9;
            m_cellSize = 1f;
            mapOriginPosition = new Vector3(0, 0, 0);  // set origin
            grid = new Grid(m_tileWidth, m_tileHeight, m_cellSize, mapOriginPosition);
        }

        [TearDown]
        public void Teardown()
        {
            
        }

        // A Test behaves as an ordinary method
        [Test]
        public void GridSpawnCorrectlyTestSimplePasses()
        {
            // Use the Assert class to test conditions
            //test grid variables are set correctly
            int gridWidth = grid.GetWorldWidth();
            Assert.AreEqual(gridWidth, m_tileWidth); // grid width
            int gridHeight = grid.GetWorldHeight();
            Assert.AreEqual(gridHeight, m_tileHeight); // grid height
            float gridCellSize = grid.GetWorldCellSize();
            Assert.AreEqual(gridCellSize, m_cellSize);  // grid cellSize (size of each cell side)
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TileChangeOnMouseClickTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            Vector3 indexOfTileToChange = new Vector3(5, 8);
            int settingValue = 7;
            grid.SetValue(indexOfTileToChange, settingValue);  // only way to simulate mouse click 
            yield return new WaitForSeconds(0.1f);
            Assert.AreEqual(grid.getValueAtPos(indexOfTileToChange), settingValue);
        }
    }
}
