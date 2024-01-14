import {MatchTreeNode} from "./match-tree-node.interface";

export interface CategoryTreeNode {
  id: number;
  name: string;
  parentId: number;
  companyName: string | null;
  totalAmount: number;
  children: CategoryTreeNode[];
  matches: MatchTreeNode[];
}
