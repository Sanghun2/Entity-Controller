## Input을 통해 Entity를 Control 할 수 있는 패키지입니다.

controller는 크게 controller, vector receiver 2가지로 구성되어 있습니다.
controller는 방향벡터를 받는 Receiver를 통해 이동 방향을 받습니다.
어떤 Receiver를 쓸지 상황에 따라 결정하고 Joystick, Axis 등에서 방향벡터를 받아올 수 있습니다.

Controller - 어떤 타입의 움직임(이동, 점프 등)인지 결정 + 이동을 최종 연산
    └ Receiver - 방향을 결정하는 source로부터 vector값을 수신
