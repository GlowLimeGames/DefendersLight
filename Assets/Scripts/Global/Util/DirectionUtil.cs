/*
 * Author: Isaiah Mann
 * Description Used to reason about directions
 */

using UnityEngine;

public static class DirectionUtil {
	public const int CARDINAL_DIRECTION_COUNT = 4;

	public static Vector2 VectorFromDirection (Direction direction) {
		switch(direction) {
		case Direction.West:
			return Vector2.left;
		case Direction.East:
			return Vector2.right;
		case Direction.North:
			return Vector2.up;
		case Direction.South:
			return Vector2.down;
		default:
			return Vector2.zero;
		}
	}

	public static Direction Clockwise90Degrees (Direction direction) {
		switch(direction) {
		case Direction.West:
			return Direction.North;
		case Direction.East:
			return Direction.South;
		case Direction.North:
			return Direction.East;
		case Direction.South:
			return Direction.West;
		default:
			return default(Direction);
		}
	}

	public static Vector2 Clockwise90DegreesVector (Direction direction) {
		return VectorFromDirection(Clockwise90Degrees(direction));
	}

	public static Vector2 ShiftPerpendicular (Direction direction, bool isClockwise = true) {
		return VectorFromDirection(PerpendicularDirection(direction, isClockwise));
	}

	public static Direction PerpendicularDirection (Direction direction, bool isClockwise = true) {
		if (direction == Direction.South) {
			return isClockwise ? Direction.West : Direction.East;
		} else if (direction == Direction.North) {
			return isClockwise ? Direction.East : Direction.West;
		} else if (direction == Direction.West) {
			return isClockwise ? Direction.North : Direction.South;
		} else if (direction == Direction.East) {
			return isClockwise ? Direction.South : Direction.North;
		} else {
			return default(Direction);
		}
	}
		
	public static Direction OppositeDirection (Direction direction) {
		int directionIndex = (int) direction;
		int dontCountZeroDirection = 1;
		// Zero direction interfereces with the math
		int directionCount = System.Enum.GetNames(typeof(Direction)).Length - dontCountZeroDirection;
		int oppositeDirectionDifference = directionCount/2;
		directionIndex += oppositeDirectionDifference;
		directionIndex %= directionCount;
		return (Direction) directionIndex;
	}

	public static int DegreesToRotate (Direction fromDirection, Direction toDirection) {
		int degreeStep = 90;
		int degrees = 0;
		int currentDirectionIndex = (int) fromDirection;
		int numDirections = System.Enum.GetNames(typeof(Direction)).Length;
		while (currentDirectionIndex != (int) toDirection) {
			currentDirectionIndex ++;
			degrees += degreeStep;
			currentDirectionIndex %= numDirections;
		}
		return degrees;
	}

	// Degrees to rotate from North
	public static int GetAngleFromDirection (Direction direction) {
		if (direction == Direction.North) {
			return 0;
		} else if (direction == Direction.West) {
			return 90;
		} else if (direction == Direction.South) {
			return 180;
		} else if (direction == Direction.East) {
			return 170;
		} else {
			// TODO: Implement the rest of the directions later
			return 0;
		}
	}

	public static Direction GetDirection (MapLocation directionVector) {
		if (directionVector.X > 0) {		
			if (directionVector.Y > 0) {
				return Direction.NorthEast;
			} else if (directionVector.Y == 0) {
				return Direction.East;
			} else {
				return Direction.SouthEast;
			}
		} else if (directionVector.X == 0) {
			if (directionVector.Y > 0) {
				return Direction.North;
			} else if (directionVector.Y == 0) {
				return Direction.Zero;
			} else {
				return Direction.South;
			}
		} else {
			if (directionVector.Y > 0) {
				return Direction.NorthWest;
			} else if (directionVector.Y == 0) {
				return Direction.West;
			} else {
				return Direction.SouthWest;
			}
		}
	}

	public static Direction DirectionFromVector (Vector3 vector) {
		return DirectionFromVector((Vector2) vector);
	}

	public static Direction DirectionFromVector (Vector2 vector) {
		float x = vector.x;
		float y = vector.y;
		if (Mathf.Sign(x) == 1) {
			if (Mathf.Sign(y) == 1) {
				return Direction.NorthEast;
			} else if (Mathf.Sign(y) == -1) {
				return Direction.SouthEast;
			} else {
				return Direction.East;
			}
		} else if (Mathf.Sign(x) == -1) {
			if (Mathf.Sign(y) == 1) {
				return Direction.NorthWest;
			} else if (Mathf.Sign(y) == -1) {
				return Direction.SouthWest;
			} else {
				return Direction.West;
			}
		} else {
			if (Mathf.Sign(y) == 1) {
				return Direction.North;
			} else if (Mathf.Sign(y) == -1) {
				return Direction.South;
			} else {
				return Direction.Zero;
			}
		}
	}

	public static Direction RandomCardinalDirection () {
		return (Direction) Random.Range(0, DirectionUtil.CARDINAL_DIRECTION_COUNT);
	}
}