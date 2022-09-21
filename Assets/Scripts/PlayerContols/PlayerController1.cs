using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{

    //Variables extras
    bool cooldown = false;

    //Variables movimiento
    float horizontalMove;
    float verticalMove;
    bool isRunning;

    private Vector3 playerInput;

    public CharacterController player;
    public float inputPlayerSpeed;
    private float playerSpeed;
    public float currentSpeed;
    public float gravity;
    public float fallVelocity;
    public float jumpForce;

    private float punchSelect;
    private bool canPunch = true;

    public GameObject leftHand, rightHand;

    //Varaibles movimiento relativo a camara
    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 movePlayer;

    //Variables deslizamiento en pendientes
    public bool isOnSlope = false;
    private Vector3 hitNormal;
    public float slideVelocity;
    public float slopeForceDown;

    //Variables anim
    private Animator playerAnimatorControler;

    // Cargamos el componente CharacterController en la variable player al iniciar el script
    void Start()
    {
        player = GetComponent<CharacterController>();
        playerAnimatorControler = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked; //Para que no aparezca el mouse en la pantalla

        playerSpeed = inputPlayerSpeed;

    }

    // Bucle de juego que se ejecuta en cada frame
    void Update()
    {
        //Guardamos el valor de entrada horizontal y vertical para el movimiento
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        playerInput = new Vector3(horizontalMove, 0, verticalMove); //los almacenamos en un Vector3
        playerInput = Vector3.ClampMagnitude(playerInput, 1); //Y limitamos su magnitud a 1 para evitar aceleraciones en movimientos diagonales

        playerAnimatorControler.SetFloat("PlayerWalkVelocity", playerInput.magnitude * playerSpeed);

        CamDirection(); //Llamamos a la funcion CamDirection()

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;  //Almacenamos en movePlayer el vector de movimiento corregido con respecto a la posicion de la camara.

        movePlayer = movePlayer * playerSpeed;  //Y lo multiplicamos por la velocidad del jugador "playerSpeed"

        player.transform.LookAt(player.transform.position + movePlayer); //Hacemos que nuestro personaje mire siempre en la direccion en la que nos estamos moviendo.

        SetGravity(); //Llamamos a la funcion SetGravity() para aplicar la gravedad

        PlayerSkills(); //Llamamos a la funcion PlayerSkills() para invocar las habilidades de nuestro personaje
        
        player.Move(movePlayer * Time.deltaTime); //Y por ultimo trasladamos los datos de movimiento a nuestro jugador * Time.deltaTime 
                                                  //De este modo mantenemos unos FPS estables independientemente de la potencia del equipo.
                                                  //Debug.Log("Tocando el suelo: " + player.isGrounded); //Descomenta esta linea si quieres monitorizar si estas tocando el suelo en la consola de depuracion

        currentSpeed = player.velocity.magnitude;

        if (Input.GetKey(KeyCode.LeftShift)) //Para que el personaje corra, tener en cuenta que esto es para cuando la playerSpeed es 5, si no es 5 hay que modificar
        {
            isRunning = true;
            playerSpeed = inputPlayerSpeed * 2;
        }
        else
        {
            isRunning = false;
            playerSpeed = inputPlayerSpeed;
        }
    }

    //Funcion para determinar la direccion a la que mira la camara. 
    public void CamDirection()
    {
        //Guardamos los vectores correspondientes a la posicion/rotacion de la carama tanto hacia delante como hacia la derecha.
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;
        //Asignamos los valores de "y" a 0 para no crear conflictos con otras operaciones de movimiento.
        camForward.y = 0;
        camRight.y = 0;
        //Y normalizamos sus valores.
        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }

    //Funcion para las habilidades de nuestro jugador.

    public void PlayerSkills()
    {
        //Si estamos tocanto el suelo y pulsamos el boton "Jump"
        if (player.isGrounded && Input.GetButtonDown("Jump"))
        {
            fallVelocity = jumpForce; //La velocidad de caida pasa a ser igual a la velocidad de salto
            movePlayer.y = fallVelocity; //Y pasamos el valor a movePlayer.y
            playerAnimatorControler.SetTrigger("PlayerJump");
        }

        if (player.isGrounded && Input.GetMouseButtonDown(0))
        {
            if (canPunch)
            {
                StartCoroutine(playerPunchCoroutine());
            }
        }
    }

    IEnumerator playerPunchCoroutine()
    {
        canPunch = false;
        playerAnimatorControler.SetBool("PlayerPunchFinished", false);

        punchSelect = Random.Range(0, 3);

        playerAnimatorControler.SetFloat("PlayerPunchSelect", punchSelect);

        playerAnimatorControler.SetTrigger("PlayerPunch");

        yield return new WaitForSeconds(1f);

        playerAnimatorControler.SetBool("PlayerPunchFinished", true);
        canPunch = true;

    }

    //Funcion para la gravedad.
    public void SetGravity()
    {
        //Si estamos tocando el suelo
        if (player.isGrounded)
        {
            //La velocidad de caida es igual a la gravedad en valor negativo * Time.deltaTime.
            fallVelocity = -gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        else //Si no...
        {
            playerAnimatorControler.SetFloat("PlayerVerticalVelocity", player.velocity.y);
            //aceleramos la caida cada frame restando el valor de la gravedad * Time.deltaTime.
            fallVelocity -= gravity * Time.deltaTime;
            movePlayer.y = fallVelocity;
        }
        playerAnimatorControler.SetBool("IsGrounded", player.isGrounded);
        SlideDown(); //Llamamos a la funcion SlideDown() para comprobar si estamos en una pendiente
    }

    //Esta funcion detecta si estamos en una pendiente muy pronunciada y nos desliza hacia abajo.
    public void SlideDown()
    {
        //si el angulo de la pendiente en la que nos encontramos es mayor o igual al asignado en player.slopeLimit, isOnSlope es VERDADERO
        isOnSlope = Vector3.Angle(Vector3.up, hitNormal) >= player.slopeLimit;

        if (isOnSlope) //Si isOnSlope es VERDADERO
        {
            //movemos a nuestro jugador en los ejes "x" y "z" mas o menos deprisa en proporcion al angulo de la pendiente.
            movePlayer.x += ((1f - hitNormal.y) * hitNormal.x) * slideVelocity;
            movePlayer.z += ((1f - hitNormal.y) * hitNormal.z) * slideVelocity;
            //y aplicamos una fuerza extra hacia abajo para evitar saltos al caer por la pendiente.
            movePlayer.y += slopeForceDown;
        }
    }

    IEnumerator waitForCooldown() //Cooldown para esperar un segundo al sacarme vida
    {
        cooldown = true;
        yield return new WaitForSeconds(1);
        cooldown = false;
    }

    //Esta funcion detecta cuando colisinamos con otro objeto mientras nos movemos
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Almacenamos la normal del plano contra el que hemos chocado en hitNormal.
        hitNormal = hit.normal;
        
        if (hit.collider.gameObject.tag == "5-Damage" && cooldown == false) //Para sacar vida
        {
            HealthBar.vidaActual -= 5;
            StartCoroutine(waitForCooldown()); //Que espere un segundo
        }
    }

    private void OnAnimatorMove()
    {

    }

    public void ActivatePunchHitbox()
    {
        leftHand.SetActive(true);
    }

    public void DesactivatePunchHitbox()
    {
        leftHand.SetActive(false);
    }

    public void ActivateRightPunchHitbox()
    {
        rightHand.SetActive(true);
    }

    public void DesactivateRightPunchHitbox()
    {
        rightHand.SetActive(false);
    }
}



