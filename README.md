# UI


- 캔버스
    초기값 비활성화 포지션 화면 밖 불리언 false
  - 이미지
    초기값 필어마운트 0  로테이션 360
    - 버튼들


## 온마우스 클릭다운
  - 만약 소스 이미지가 널값이 아님
    - 클릭카운트 증가
    만약 클릭카운트가 2개라면
  클릭카운트 0;
  불리언 true
  캔버스 활성화
  캔버스 포지션 == 마우스 포지션
  1초 동안 필어마운트 1 , 로테이션 0 으로 변환.


- 온마우스 클릭업
만약 불리언이 트루라면
  클릭카운트++
  만약 클릭카운트가 2라면
   클릭카운트 0
   불리언 false
   1초동안 필어마운트 0 로테이션 360
   캔버스 포지션 == 화면 밖
  캔버스 비활성화
