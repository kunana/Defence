using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    // 스코어를 표시해주는 클래스

    // 스코어 이미지를 받음 0~9
    public GameObject[] scoreImage = new GameObject[10];

    // 애니메이션 효과를 체크할 변수
    private bool aniscore = false;
    private int prevScore = 0;
    private int myScore = 0;
    private int scoreCount = 0;
    private char myAlign;
    private Vector2 nowPosition = Vector2.zero;
    private float t = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 애니메이션효과가 true면
        if (aniscore == true)
        {
            // Math 함수를 쓰기위해 임시 float으로 변경
            float endScore = (float)myScore;
            // Mathf.Lerp 함수를 써서 시간마다 prev -> mySCore로 점점 nowScore가 올라가게함
            int nowScore = (int)Mathf.Lerp(prevScore, endScore, t);

            // 기존에 있던거 다지우고
            removeAllChildren();

            // 새로운 숫자출력
            if (myAlign == 'r' || myAlign == 'R')
                RightAlign(nowScore, nowPosition);
            if (myAlign == 'l' || myAlign == 'L')
                LeftAlign(nowScore, nowPosition, scoreCount);

            t += Time.deltaTime;

            // 1초가 넘으면 마지막으로 한번더 지우고 최종 숫자 출력
            if (t >= 1.0f)
            {
                removeAllChildren();
                if (myAlign == 'r' || myAlign == 'R')
                    RightAlign(myScore, nowPosition);
                if (myAlign == 'l' || myAlign == 'L')
                    LeftAlign(myScore, nowPosition, scoreCount);

                // 이전 스코어 = 현재스코어 넣어줌. 효과 false로. 시간초기화
                prevScore = myScore;
                aniscore = false;
                t = 0.0f;
            }

        }
    }

    // 스코어를 출력하는 함수
    public void printScore(int Score, Vector2 position, char align, bool ani = false)
    {
        // 입력받은 변수를 전역변수로 넣어줌. 애니메이션 효과를 update에서 하기위해
        aniscore = ani;
        myScore = Score;
        nowPosition = position;
        myAlign = align;

        // 자리수 구하기 위한 현재숫자
        int nowNum = 1;
        // 자리수
        int count = 0;

        if (Score == 0)
        {
            // 스코어가 0이면 이전스코어도 0으로
            prevScore = 0;
            count = 1;
        }
        else
        {
            // 자리수 구하기
            while (Score / nowNum != 0)
            {
                count++;
                nowNum *= 10;
            }
        }

        // 자리수도 전역변수로 넣어줌
        scoreCount = count;

        // 애니메이션효과가 true일때
        if (ani == true)
        {

        }
        // false일때
        else
        {
            // 기존 스코어이미지 삭제 후 생성
            removeAllChildren();

            // 왼쪽, 오른쪽 정렬따라 다르게 실행함
            if (align == 'r' || align == 'R')
                RightAlign(Score, position);
            if (align == 'l' || align == 'L')
                LeftAlign(Score, position, count);
        }
    }

    // 자식들 전부삭제하는 함수만듬
    public void removeAllChildren()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    // 오른쪽정렬
    public void RightAlign(int Score, Vector2 position)
    {
        if (Score == 0)
        {
            var makenumber = Instantiate(scoreImage[0], transform);
            makenumber.transform.position = new Vector2(position.x, position.y);
        }
        else
        {
            int count = 0;
            while (Score > 0)
            {
                int num = Score % 10;
                Score = Score / 10;

                var makenumber = Instantiate(scoreImage[num], transform);
                makenumber.transform.position = new Vector2(position.x - count * 0.4f, position.y);

                count++;
            }
        }
    }

    // 왼쪽정렬
    public void LeftAlign(int Score, Vector2 position, int count)
    {
        if (Score == 0)
        {
            var makenumber = Instantiate(scoreImage[0], transform);
            makenumber.transform.position = new Vector2(position.x, position.y);
        }
        else
        {
            // 위치를 잡기위한 변수
            int lcount = 0;
            for (int i = count - 1; i >= 0; i--)
            {
                int num = Score / (int)Mathf.Pow(10, (float)i);
                Score = Score % (int)Mathf.Pow(10, (float)i);

                var makenumber = Instantiate(scoreImage[num], transform);
                makenumber.transform.position = new Vector2(position.x + lcount * 0.3f, position.y);

                lcount++;
            }
        }
    }
}
