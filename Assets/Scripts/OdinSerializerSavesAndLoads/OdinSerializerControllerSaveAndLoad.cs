using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using OdinSerializer;
using Scripts.GameMenuScripts;
using UnityEngine;
using UnityEngine.UI;


namespace Scripts.OdinSerializerSavesAndLoads
{
    public class OdinSerializerControllerSaveAndLoad : MonoBehaviour
    {
        public const string CountFileKey = "count_file";

        //[HideInInspector] public bool isCanShowField;

        //[Header("Hide field")]
        //[HideInInspector] public PlayerTransform playerTransform;
        //[SerializeField] PlayerTransform playerTransform;

        static SaveDataPlayer saveDataPlayer;

        internal int countFile;

        private FileStream fileStream;
        static BinaryFormatter binaryFormatter = new BinaryFormatter();

        //public List<int> commonCountFile;
        //protected int currentSaveFile;
        //protected int deleteUselessButtons = 0;

        //[SerializeField] List<Button> buttonList;
        //[SerializeField] Button buttonLoadGame;
        //[SerializeField] protected GameObject contentScrollView;
        //[SerializeField] protected ShowTextLoadButtons showTextLoadButtons;

        //private static Vector3 _playerPosition;
        //private static Quaternion _playerRotation;

        static string FilePath = "C:/Users/Impossible/AppData/LocalLow/Noise Wind/NewForgive/";

        /*public GameObject[] itemInteraction
        {
            get { return this.saveDataPlayer.itemInteract; }
            set { this.saveDataPlayer.itemInteract = value; }
        }*/


        /*public GameObject[] toggleIsOnInNotepad
        {
            get { return this.saveDataPlayer.toggleIsOnInNotepad; }
            set { this.saveDataPlayer.toggleIsOnInNotepad = value; }
        }*/

        private void Awake()
        {
            if (PlayerPrefs.HasKey(CountFileKey)) 
            {
                countFile = PlayerPrefs.GetInt(CountFileKey);
                Debug.Log("Загрузка файла под номером: " + countFile);

                if (PlayerPrefs.HasKey(ILoadScene.HasButtonPressKey))
                {
                    ILoadScene.hasButtonPress = PlayerPrefs.GetInt(ILoadScene.HasButtonPressKey);

                    Debug.Log("Нажатие кнопки загрузки [ЗАГРУЗИЛОСЬ]");

                    if (ILoadScene.hasButtonPress == 1)
                    {
                        // загружаем сохраненные данные игрока
                        LoadData(); // также это поможет продолжать игру, а не начинать ее заного
                        ILoadScene.hasButtonPress = 0;
                    }
                }


                // загружаем необходимую кнопку загрузки в панели загрузок
                //showTextLoadButtons.LoadTextForLoadButtons(); 

                //if (countFile != 0)
                  //  ShowLoadGameButton(); // сохранение кнопок есть, НО из-за того что я их сохраняю через PlayerPrefs
                                          // они показываются(подгружаются) даже если в папке нету этого сохранения
            }
        }

        private void Start()
        {
            Debug.Log(Application.persistentDataPath);
        }

        /*private void Update()
        {
            if(Input.GetKeyDown(KeyCode.F5))
                SaveData();
        }*/

        public void SaveData()
        {
            countFile++;
            //commonCountFile.Add(countFile);

            CommonSaveData();

            byte[] bytes = SerializationUtility.SerializeValue(saveDataPlayer, DataFormat.Binary);

            // данная конструкция позволяет автоматически закрывать поток Stream (не вызывая методы fileStream.Dispose или fileStream.Close)
            using FileStream fileStream = new FileStream(FilePath + "Autosave_" + countFile + ".log", FileMode.Create);

            binaryFormatter.Serialize(fileStream, bytes);

            Debug.Log("Saved Data for Autosave_" + countFile + ".log");

            //ShowLoadGameButton();
            PlayerPrefs.SetInt(CountFileKey, countFile);
            //showTextLoadButtons.SaveTextForLoadButtons();
        }

        public void LoadData()
        {
            // данная конструкция позволяет автоматически закрывать поток Stream (не вызывая методы fileStream.Dispose или fileStream.Close)
            using FileStream fileStream = new FileStream(FilePath + "Autosave_" + countFile + ".log", FileMode.Open);

            byte[] bytes = (byte[])binaryFormatter.Deserialize(fileStream);
            saveDataPlayer = SerializationUtility.DeserializeValue<SaveDataPlayer>(bytes, DataFormat.Binary);

            CommonLoadData();

            Debug.Log("Load Data from Autosave_" + countFile + ".log");
        }

        public void CommonLoadData()
        { 
            this.transform.position = SaveDataPlayer.playerPosition; // не загружает игрока на нужную сохраненную позицию
            this.transform.rotation = SaveDataPlayer.playerRotation;

            //this.itemInteraction = this.saveDataPlayer.itemInteract;

            //this.toggleIsOnInNotepad = this.saveDataPlayer.toggleIsOnInNotepad;
        }

        public void CommonSaveData() 
        {
            SaveDataPlayer.playerPosition = this.transform.position;
            SaveDataPlayer.playerRotation = this.transform.rotation;

            //this.saveDataPlayer.itemInteract = this.itemInteraction;

            //this.saveDataPlayer.toggleIsOnInNotepad = this.toggleIsOnInNotepad;
        }

        /*public void ShowLoadGameButton()
        {
            showTextLoadButtons.ShowTextButton(countFile);
            Button button = Instantiate(buttonLoadGame, contentScrollView.transform);
            buttonList.Add(button);

            button.name = $"Button Load Game (Clone) ({countFile})";
        }*/
    }

}

[Serializable]
public class SaveDataPlayer
{
    [Header("Position and Rotation")]
    public static Vector3 playerPosition;
    public static Quaternion playerRotation;

    //public GameObject[] itemInteract;
    //public GameObject[] toggleIsOnInNotepad;
}
