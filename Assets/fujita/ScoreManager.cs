using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private int score = 0;
    [SerializeField] TextMeshProUGUI timeTxet;
    [SerializeField] private float leftTime = 30;
    //����stageCount�̓X�e�[�W�N���A���Ƃ�"�C���N�������g"���Ă�������
    public int stageCount = 1;
    //timeCount�̓X�e�[�W�N���A���Ƃ�"false"�ɂ��Ă�������
    //���̃X�e�[�W���J�n����Ƃ���"true"�ɂ��Ă�������
    public bool timeCount = true;
    void Start()
    {
        SetScoreTxet();
    }
    void Update()
    {
        if (timeCount)
        {
            leftTime -= Time.deltaTime;
            timeTxet.text = "Time:" + Mathf.RoundToInt(leftTime);
            //lefttime��0�ɂȂ�����~�܂�悤�ɂ��܂�
            if (leftTime <= 0)
            {
                timeCount = false;
                //�����̓Q�[���I�[�o�[�̏����ɂ��g���܂�
            }
        }
    }
    //���̊֐��̓X�e�[�W���N���A���邲�Ƃɗ��p���Ă�������
    public void AddScore()
    {
        score += Mathf.RoundToInt(leftTime) * stageCount;
        scoreText.text = "SCORE:" + score;
    }
    //�X�R�A�������p�֐�
    private void SetScoreTxet()
    {
        scoreText.text = "SCORE:" + score;
    }
}