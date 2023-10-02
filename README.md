# VideoPlayerProject
## 소개
- 유튜브 동영상들을 분류별로 저장하여 볼 수 있는 앱
- 기능
    1. 동영상 종료시 해당 동영상의 재생시간을 저장하여 다시 재생시 해당 부분부터 재생
    2. 개별 동영상의 달성률과 해당 분류의 전체 달성률을 확인
    3. 사용자의 취향대로 동영상의 카테고리를 분류하여 저장
    4. 유튜브 api를 활용하여 동영상 추가시 썸네일 및 기본 정보 저장
## mainForm
<img src = "https://github.com/gyudong0908/VideoPlayerProject/assets/121427661/cdf9baea-d784-4c3f-8d48-3841b95233c6" width = "700px" height="500px"></img>
## InputUrlForm
<img src = "https://github.com/gyudong0908/VideoPlayerProject/assets/121427661/614677d1-485b-44c6-a582-ce86a3ae2ad2" width = "700px" height="200px"></img>
## PlayerForm
<img src = "https://github.com/gyudong0908/VideoPlayerProject/assets/121427661/fee16217-14ba-4dec-9dfa-8e949aa6e622" width = "700px" height="500px"></img>

## 어려웠던 점
1. 자식 컨트롤러의 삭제버튼을 누르면 해당 컨트롤러를 포함한 부모 form의 panel에서 삭제되는 기능<br/>
> 삭제버튼은 자식 컨트롤러에서 눌리지만 삭제 로직은 부모 form에서 실행 되야 하므로 해당 기능을 구현하는것이 고민이었다. 해당 기능은 delegate를 사용하여 자식 컨트롤러를 생성할 때, 부모 form에서 해당 함수를 넘겨주어 구현하였다.
2. 동영상이 재생되는 창을 닫았을 경우 재생시간이 기록되지 않고 먼저 종료되는 오류<br/>
> 해당 form을 닫는 경우 재생시간이 저장되는 코드가 모두 실행되기 전에 form이 먼저 closing이 되어 저장이 되지 않는 오류가 자주 발생하였다. 이를 해결하기 위해 동기화를 하여 await문을 사용하여 작성해 보았지만 그럼에도 동작이 되지 않아 isClose이라는 변수로 확인을 하고 모든 코드가 실행 되고 난 뒤 form이 닫힐 수 있도록 구현하였다.
3. .net framework의 기본 웹 브러우저의 호환성 문제<br/>
> .net framework에서 기본적으로 지원하는 웹 브라우저의 경우에는 호환성 문제로 인해서 유튜브 동영상을 재생할 수 없었다. 따라서 이에 대한 해결책으로 Chromium 브러우저 api를 사용하여 해결하였다.
## 배웠던 점
1. .net framework 기본적인 컨트롤러 사용
2. db와 연결하는 repository의 경우 객체를 여러개 만들 필요가 없으니 이 부분을 싱글톤패턴으로 구현하여 사용
